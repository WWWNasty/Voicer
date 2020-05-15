using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Extensions;
using BusinessLogicLayer.Abstraction.Repositories;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Chats;
using DataAccessLayer.Models.Users;
using DataAccessLayer.Models.Votes;
using DataAccessLayer.Models.Votes.Enums;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands
{
    public class VotingService : IVotingService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public VotingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<UpdateVotingDto> GetVotingForUpdateAsync(int id)
        {
            return _unitOfWork.VotingRepository.GetVotingForUpdateAsync(id);
        }

        public async Task<GetAllVotingDto> GetAllVotingAsync(string userId)
        {
            var allVoting = await _unitOfWork.VotingRepository.GetAllAsync(userId);

            return new GetAllVotingDto()
            {
                ActiveVoting = GetVotingWithStatus(allVoting, VotingStatus.Active),
                UpcomingVoting = GetVotingWithStatus(allVoting, VotingStatus.Upcoming),
                ClosedVoting = GetVotingWithStatus(allVoting, VotingStatus.Ended)
            };
        }

        private ICollection<VotingDto> GetVotingWithStatus(ICollection<Voting> allVoting, VotingStatus status)
        {
            return _mapper.Map<ICollection<VotingDto>>(allVoting.Where(voting => voting.GetVotingStatus() == status));
        }

        public async Task DeleteAsync(DeleteVotingDto votingDto)
        {
            var voting = await _unitOfWork.VotingRepository.GetAsync(votingDto.Id);
            if (voting != null && voting.UserId == votingDto.User.GetUserId())
            {
                _unitOfWork.VotingRepository.Delete(voting);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<bool> HasUserVotedAsync(int votingId, string userId)
        {
            return await _unitOfWork.VoteRepository.UserHasVotedAsync(votingId, userId);
        }

        public async Task<int> AddAsync(CreateVotingDto dto, ClaimsPrincipal user)
        {
            var voting = _mapper.Map<Voting>(dto);

            voting.UserId = user.GetUserId();

            voting.Chat = new Chat();

            _unitOfWork.VotingRepository.Create(voting);

            await _unitOfWork.SaveChangesAsync();

            return voting.Id;
        }

        public async Task UpdateAsync(UpdateVotingDto dto)
        {
            var voting = await _unitOfWork.VotingRepository.Get(new GetOptions
            {
                Id = dto.Id,
                IncludeVotingOptions = true
            });
            ;

            if (voting.GetVotingStatus() == VotingStatus.Upcoming)
            {
                _mapper.Map(dto, voting);

                _unitOfWork.VotingRepository.Update(voting);

                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task InviteAsync(InviteUserDto dto)
        {
            //достать сущьность головонния из репозитория потом добавить в нее участников голосования пользователя который достанем из репозитория пользователей сохраним изменения
            Voting voting = await _unitOfWork.VotingRepository.Get(new GetOptions
            {
                Id = dto.VotingId,
                IncludeParticipants = true
            });
            User findUserByEmail = await _unitOfWork.UserRepository.FindUserByEmailAsync(dto.Email);
            if (voting != null && findUserByEmail != null &&
                voting.Participants.All(user => user.UserId != findUserByEmail.Id))
            {
                voting.Participants.Add(new UserVoting
                {
                    User = findUserByEmail,
                    Voting = voting
                });
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task MakeVoteAsync(MakeVoteDto dto)
        {
            VotingOption votingOption = await _unitOfWork.VotingOptionRepository.GetAsync(dto.VotingOptionId);

            var votingId = votingOption.VotingId;

            if (!await _unitOfWork.VoteRepository.UserHasVotedAsync(votingId!.Value, dto.User.GetUserId()))
            {
                _unitOfWork.VoteRepository.Create(new Vote()
                {
                    VotingOptionId = votingOption.Id,
                    VotingId = votingId.Value,
                    UserId = dto.User.GetUserId()
                });
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<GetVotingDto> GetVotingAsync(int id)
        {
            var votingDto = await _unitOfWork.VotingRepository.GetVotingDtoAsync(id);
            if (votingDto == null)
            {
                return null;
            }

            votingDto.VoteCountByVotingOptionDto = await _unitOfWork.VoteRepository.GetCountVoteAsync(id);
            return votingDto;
        }
    }
}
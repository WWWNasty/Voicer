using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Extensions;
using BusinessLogicLayer.Abstraction.Repositories;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Users;
using DataAccessLayer.Models.Votes;
using DataAccessLayer.Models.Votes.Enums;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands
{
    public class VotingService: IVotingService
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

        public async Task<GetAllVotingDto> GetAllVotingAsync()
        {
            var allVoting = await _unitOfWork.VotingRepository.GetAllAsync();

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
                
            }
            
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> AddAsync(CreateVotingDto dto, ClaimsPrincipal user)
        {
            var voting = _mapper.Map<Voting>(dto);

            voting.UserId = user.Claims
                .Where(claim => claim.Type == ClaimTypes.NameIdentifier)
                .Select(claim => claim.Value)
                .First();
                
            _unitOfWork.VotingRepository.Create(voting);

            await _unitOfWork.SaveChangesAsync();

            return voting.Id;
        }

        public async Task UpdateAsync(UpdateVotingDto dto)
        {
            var voting = await _unitOfWork.VotingRepository.GetAsync(dto.Id);

            _mapper.Map(dto, voting);
            
            _unitOfWork.VotingRepository.Update(voting);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InviteAsync(InviteUserDto dto)
        {
            //достать сущьность головонния из репозитория потом добавить в нее участников голосования пользователя который достанем из репозитория пользователей сохраним изменения
            Voting voting = await _unitOfWork.VotingRepository.GetAsync(dto.VotingId);
            User findUserByEmail = _unitOfWork.UserRepository.FindUserByEmail(dto.Email);
            if (voting != null && findUserByEmail != null)
            {
                voting.Participants.Add(new UserVoting
                {
                    User = findUserByEmail,
                    Voting = voting
                });
            }
            
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<GetVotingDto> GetVotingAsync(int id) => _unitOfWork.VotingRepository.GetVotingDtoAsync(id);
        
        
    }
}
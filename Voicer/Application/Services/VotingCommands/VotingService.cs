using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Repositories;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Votes;

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

        public Task<List<GetAllVotingDto>> GetAllVotingAsync() => _unitOfWork.VotingRepository.GetAllVotingDtosAsync();

        public async Task DeleteAsync(DeleteVotingDto dto)
        {
            var voting = await _unitOfWork.VotingRepository.GetAsync(dto.Id);
            
            _unitOfWork.VotingRepository.Delete(voting);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> AddAsync(CreateVotingDto dto)
        {
            var voting = _mapper.Map<Voting>(dto);

            _unitOfWork.VotingRepository.Create(voting);

            await _unitOfWork.SaveChangesAsync();

            return voting.Id;
        }

        public async Task Update(UpdateVotingDto dto)
        {
            var voting = await _unitOfWork.VotingRepository.GetAsync(dto.Id);

            _mapper.Map(dto, voting);
            
            _unitOfWork.VotingRepository.Update(voting);

            await _unitOfWork.SaveChangesAsync();
        }

        public Task Invite(InviteUserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<GetVotingDto> GetVotingAsync(int id) => _unitOfWork.VotingRepository.GetVotingDtoAsync(id);
        
        
        
    }
}
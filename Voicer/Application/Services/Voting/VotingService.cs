using System.Collections.Generic;
using BusinessLogicLayer.Abstraction.Repositories;

namespace BusinessLogicLayer.Abstraction.Services.Voting
{
    public class VotingService: IVotingService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public VotingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICollection<VotingDto> GetVoting() => _unitOfWork.VotingRepository.GetVoting();
    }
}
using System.Collections.Generic;
using BusinessLogicLayer.Abstraction.Repositories.Base;
using BusinessLogicLayer.Abstraction.Services.Voting;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Abstraction.Repositories
{
    public interface IVotingRepository: IBaseRepository<Voting, int>
    {
        ICollection<VotingDto> GetVoting();
    }
}
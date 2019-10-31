using System.Collections.Generic;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Abstraction.Repositories
{
    public interface IVotingRepository
    {
        ICollection<Voting> GetVoting();
    }
}
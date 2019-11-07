using System.Collections.Generic;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Abstraction.Services.ListVoting
{
    public interface IVotingService
    {
        ICollection<VotingDto> GetVoting();
    }
}
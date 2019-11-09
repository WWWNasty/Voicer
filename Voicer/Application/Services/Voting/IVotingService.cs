using System.Collections.Generic;

namespace BusinessLogicLayer.Abstraction.Services.Voting
{
    public interface IVotingService
    {
        ICollection<VotingDto> GetVoting();
    }
}
using System.Collections.Generic;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class VoteCountByVotingOptionDto
    {
        public int VotingId { get; set; }

        public Dictionary<int, int> VotingOptionCount { get; set; }
    }
}
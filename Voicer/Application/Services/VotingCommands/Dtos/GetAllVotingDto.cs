using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class GetAllVotingDto
    {
        public ICollection<VotingDto> UpcomingVoting { get; set; }
        
        public ICollection<VotingDto> ActiveVoting { get; set; }
        
        public ICollection<VotingDto> ClosedVoting { get; set; }

    }
}
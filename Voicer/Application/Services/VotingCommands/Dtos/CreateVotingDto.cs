using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class CreateVotingDto
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public ICollection<VotingOptionDto> VotingOptions { get; set; }

    }
}
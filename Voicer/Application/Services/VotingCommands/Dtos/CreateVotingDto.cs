using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class CreateVotingDto
    {
        public const int VotingOptionsCount = 5;
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public VotingOptionDto[] VotingOptions { get; set; } = new VotingOptionDto[VotingOptionsCount];

    }
}
using System;
using System.Collections.Generic;
using DataAccessLayer.Models.Votes.Enums;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class GetVotingDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public ICollection<VotingOptionDto> VotingOptions { get; set; }
        public UserDto User { get; set; }

        public ICollection<UserVotingDto> Participants { get; set; }

        public VotingStatus VotingStatus { get; set; }
    }
}
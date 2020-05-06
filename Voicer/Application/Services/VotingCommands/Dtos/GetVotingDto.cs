using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Votes.Enums;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class GetVotingDto
    {
        public int Id { get; set; }

        [Required] 
        [MaxLength(100)] 
        public string Name { get; set; }
        
        [Required] 
        [MaxLength(500)] 
        public string Description { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        [MinLength(1)]
        public VotingOptionDto[] VotingOptions { get; set; }
        
        [Required]
        public UserDto User { get; set; }

        public ICollection<UserVotingDto> Participants { get; set; }
        
        public ICollection<VoteDto> Votes { get; set; }

        [Required]
        public VotingStatus VotingStatus { get; set; }

        public bool UserVoted { get; set; }
    }
}
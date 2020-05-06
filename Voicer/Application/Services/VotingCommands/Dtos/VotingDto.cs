using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Users;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class VotingDto
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        public UserDto User { get; set; }
        
        public ICollection<UserVotingDto> Participants { get; set; }

    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class UserDto
    {
        
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<VotingDto> CreatedVoting { get; set; }
        
        public ICollection<UserVotingDto> UserVoting { get; set; } 

        //public ICollection<Vote> Votes { get; set; }
    }
}
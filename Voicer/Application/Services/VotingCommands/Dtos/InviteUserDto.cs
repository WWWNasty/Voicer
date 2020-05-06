using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Users;
using DataAccessLayer.Models.Votes;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class InviteUserDto
    {
        [Required]
        public int VotingId { get; set; }

        public ICollection<UserVotingDto> Participants { get; set; }

        
        public string UserId { get; set; }
        
        [Required]
        public string Email { get; set; }
    }
}
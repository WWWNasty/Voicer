using System.Collections.Generic;
using DataAccessLayer.Models.Users;
using DataAccessLayer.Models.Votes;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class InviteUserDto
    {
        public int VotingId { get; set; }

        public ICollection<UserVotingDto> Participants { get; set; }

        public string UserId { get; set; }
        
        public string Email { get; set; }
    }
}
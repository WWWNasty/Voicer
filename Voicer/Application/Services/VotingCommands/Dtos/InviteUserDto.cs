using DataAccessLayer.Models.Users;
using DataAccessLayer.Models.Votes;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class InviteUserDto
    {
        public int VotingId { get; set; }

        public int UserId { get; set; }
    }
}
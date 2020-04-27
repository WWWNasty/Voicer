using System.Security.Claims;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class DeleteVotingDto
    {
        public int Id { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
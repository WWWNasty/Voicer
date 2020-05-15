using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class DeleteVotingDto
    {
        public int Id { get; set; }

        [Required]
        public ClaimsPrincipal User { get; set; }
    }
}
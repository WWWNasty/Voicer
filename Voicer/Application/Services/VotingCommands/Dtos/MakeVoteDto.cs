using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class MakeVoteDto
    {
        [Required] public int VotingOptionId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
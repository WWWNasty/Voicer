using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class VoteDto
    { 
        public VotingOptionDto VotingOption { get; set; }

    }
}
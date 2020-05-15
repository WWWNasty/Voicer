using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class MessageDto
    {
        [Required] public string Text { get; set; }

        [Required] public DateTime Created { get; set; }

        [Required] public string UserId { get; set; }

        public UserDto User { get; set; }

        [Required] public int ChatId { get; set; }
    }
}
using System.Collections.Generic;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class ChatDto
    {
        public ICollection<MessageDto> Message { get; set; }
    }
}
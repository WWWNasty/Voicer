using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands
{
    public interface IChatService
    {
        Task<MessageDto> SendMessageAsync(CreateMessageDto createMessageDto);
        Task<List<MessageDto>> GetAllMessagesAsync(GetMessageQueryDto dto);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Repositories.Base;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Chats;

namespace BusinessLogicLayer.Abstraction.Repositories
{
    public interface IMessageRepository : IBaseRepository<Message, int>
    {
        Task<List<MessageDto>> GetMessages(int chatId, int page, int count);
    }
}
using BusinessLogicLayer.Abstraction.Repositories.Base;
using DataAccessLayer.Models.Chats;

namespace BusinessLogicLayer.Abstraction.Repositories
{
    public interface IChatRepository : IBaseRepository<Chat, int>
    {
    }
}
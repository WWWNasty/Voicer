using AutoMapper;
using BusinessLogicLayer.Abstraction.Repositories;
using DataAccessLayer.Models.Chats;
using Infrastructure.EntityFramework.Repositories.Base;

namespace Infrastructure.EntityFramework.Repositories
{
    public class ChatRepository : BaseRepository<Chat, int>, IChatRepository
    {
        public ChatRepository(VotingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
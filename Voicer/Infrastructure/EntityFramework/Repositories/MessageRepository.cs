using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogicLayer.Abstraction.Repositories;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Chats;
using Infrastructure.EntityFramework.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repositories
{
    public class MessageRepository : BaseRepository<Message, int>, IMessageRepository
    {
        public MessageRepository(VotingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Task<List<MessageDto>> GetMessages(int chatId, int page, int count)
        {
            return GetDbSet().Include(message => message.User)
                .Where(message => message.ChatId == chatId)
                .OrderByDescending(message => message.Created)
                .Skip(count * page)
                .Take(count)
                .ProjectTo<MessageDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
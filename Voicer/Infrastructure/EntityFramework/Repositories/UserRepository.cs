using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Repositories;
using DataAccessLayer.Models.Users;
using Infrastructure.EntityFramework.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repositories
{
    public class UserRepository : BaseRepository<User, string>, IUserRepository
    {
        public UserRepository(VotingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await GetDbSet().FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
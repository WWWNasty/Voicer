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

        public async Task<User> FindUser(string paramOfUserSerch)
        {
            return await GetDbSet()
                .FirstOrDefaultAsync(user => user.UserName == paramOfUserSerch || user.Email == paramOfUserSerch);
        }
    }
}
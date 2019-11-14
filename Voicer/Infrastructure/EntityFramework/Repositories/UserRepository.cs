using System;
using System.Linq;
using BusinessLogicLayer.Abstraction.Repositories.Base;
using DataAccessLayer.Models.Users;
using Infrastructure.EntityFramework.Repositories.Base;

namespace Infrastructure.EntityFramework.Repositories
{
    public class UserRepository: BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(VotingDbContext context) : base(context)
        {
        }

        public User FindUser(string search)
        {
            throw new NotImplementedException(); // GetDbSet().FirstOrDefault(user => user.Email.ToLower().Trim());
        }
    }
}
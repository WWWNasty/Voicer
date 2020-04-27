using System;
using System.Linq;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Repositories;
using BusinessLogicLayer.Abstraction.Repositories.Base;
using DataAccessLayer.Models.Users;
using Infrastructure.EntityFramework.Repositories.Base;

namespace Infrastructure.EntityFramework.Repositories
{
    public class UserRepository: BaseRepository<User, string>, IUserRepository
    {
        
        public UserRepository(VotingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public User FindUserByEmail(string email)
        { 
             return GetDbSet().FirstOrDefault(user => user.Email == email);
            
        }
    }
}
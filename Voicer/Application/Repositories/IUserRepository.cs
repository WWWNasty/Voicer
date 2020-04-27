using BusinessLogicLayer.Abstraction.Repositories.Base;
using DataAccessLayer.Models.Users;

namespace BusinessLogicLayer.Abstraction.Repositories
{
    public interface IUserRepository: IBaseRepository<User, string>
    {
       User FindUserByEmail(string search);
    }
}
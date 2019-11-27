using DataAccessLayer.Models.Users;

namespace BusinessLogicLayer.Abstraction.Repositories.Base
{
    public interface IUserRepository: IBaseRepository<User, int>
    {
       User FindUser(string search);
    }
}
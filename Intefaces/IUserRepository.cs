using WebApi_01.Entities;

namespace WebApi_01.Intefaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetById(long id);
        User CreateUser(User user);
        bool UserExist(long id);


    }
}

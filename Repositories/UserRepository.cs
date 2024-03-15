using WebApi_01.Data;
using WebApi_01.Entities;
using WebApi_01.Intefaces;

namespace WebApi_01.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            this._context = context;
        }
        public IEnumerable<User> GetUsers() 
        { 
            return _context.Users.OrderBy(x => x.Id).ToList();
        }

        public User GetById(long id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);

        }

        public User CreateUser(User user) 
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {

                _context.Users.Add(user);
                _context.SaveChanges();
                
            }
            return user; 
        }
        public bool UserExist(long userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }

    }
}

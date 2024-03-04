using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interface;

namespace BankApp.Web.Data.Repositories
{
    // implements IUserRepository. generates GetAll and GetById methods
    public class UserRepository : IUserRepository
    {
        private readonly BankContext _context;
        public UserRepository(BankContext context)
        {
            _context = context;
        }

        // all Users list getter
        // re writed to generic repository
        public List<User> GetAll()
        {
            return _context.Users.ToList();  
        }

        // user getter by id
        // re writed to generic repository
        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }
    }
}

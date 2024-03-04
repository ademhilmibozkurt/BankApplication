using BankApp.Web.Data.Entities;

namespace BankApp.Web.Data.Interface
{
    // an interface for UserRepository
    // we need to avoid new keyword and force to implement this two method on child class
    public interface IUserRepository
    {
        // list of User getter method
        List<User> GetAll();

        // get User by id
        User GetById(int id);
    }
}

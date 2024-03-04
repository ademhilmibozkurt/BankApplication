using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

// UserModel

namespace BankApp.Web.Mapping
{
    // intermediate class for User to UserModel type transition
    public interface IUserMapper
    {
        // take User type and generate UserModel type. returns UserModel
        UserModel MapToUser(User user);
        
        // different method for returning List of UserModel
        List<UserModel> MapToUserList(List<User> users);
    }
}

using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    // implements interface
    public class UserMapper : IUserMapper
    {
        // method implementation. take User type and generate UserModel type. returns UserModel
        public UserModel MapToUser(User user)
        {
            return new UserModel { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, };
        }

        // different method for returning List of UserModel
        public List<UserModel> MapToUserList(List<User> users)
        {
            return users.Select(x => new UserModel { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName }).ToList();
        }
    }
}

using BankApp.Web.Data.Entities;

namespace BankApp.Web.Data.Interface
{
    // bone structure of AccountRepository
    public interface IAccountRepository
    {
        // Account creation
        void Create(Account account);
    }
}

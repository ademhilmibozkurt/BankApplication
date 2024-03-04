using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

// AccountCreateModel

namespace BankApp.Web.Mapping
{
    // interface implementation
    public class AccountMapper : IAccountMapper
    {
        // taking model and generate Account type
        public Account Map(AccountCreateModel model)
        {
            return new Account { UserId = model.UserId, Balance = model.Balance, AccountNumber = model.AccountNumber };
        }
    }
}

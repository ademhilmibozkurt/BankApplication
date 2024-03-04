using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

// AccountCreateModel

namespace BankApp.Web.Mapping
{
    // intermediate class for AccountCreateModel to Account type transition
    public interface IAccountMapper
    {
        // generate Account type
        public Account Map(AccountCreateModel model);
    }
}

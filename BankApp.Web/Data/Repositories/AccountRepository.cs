using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interface;

namespace BankApp.Web.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        // BankContext instance and DI
        private readonly BankContext _context;
        public AccountRepository(BankContext context)
        {
            _context = context;
        }

        // moved to generic repository
        // db account creating
        public void Create(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}

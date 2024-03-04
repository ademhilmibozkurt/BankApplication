using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interface;
using BankApp.Web.Data.Repositories;

// IRepository
// Repository

namespace BankApp.Web.Data.UnitOfWork
{
    // implement IUow interface
    public class Uow : IUow
    {
        // secret BankContext instance for data gettering
        private readonly BankContext _context;

        // Uow constructor dependency injection
        public Uow(BankContext context)
        {
            _context = context;
        }

        // database data gettering method. generic(T)
        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T> (_context);
        }

        // save changes on database side
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}


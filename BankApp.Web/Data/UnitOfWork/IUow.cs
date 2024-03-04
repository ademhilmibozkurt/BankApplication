using BankApp.Web.Data.Interface;

// IRepository

// UOW : Every processes that effect database side. This effect should be controllable.
// Unit Of Work design pattern component
namespace BankApp.Web.Data.UnitOfWork
{
    // Uow interface
    public interface IUow
    {
        // forced implement save method for database data changes
        void SaveChanges();

        // get repository values. return IRepository type
        // bridge between BankContext and another classes. That provides data transferring and do not return entity directly
        IRepository<T> GetRepository<T>() where T: class, new();
    }
}

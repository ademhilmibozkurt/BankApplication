using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interface;

namespace BankApp.Web.Data.Repositories
{
    // implementing IRepository interface
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        // create instance of BankContext
        private readonly BankContext _context;

        // DI
        public Repository(BankContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            // set of T type entity inserted on db
            _context.Set<T>().Add(entity);

            // Uow says implement saveChanges method in me
            // _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            // set of T type entity deleted on db
            _context.Set<T>().Remove(entity);
            // _context.SaveChanges();
        }

        public void Update(T entity)
        {
            // set of T type entity changed on db
            _context.Set<T>().Update(entity);
            // _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            // set of T entity gettering
            return _context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            // get T entity with object id from db
            return _context.Set<T>().Find(id);
        }

        // query runs on db during program running
        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}

namespace BankApp.Web.Data.Interface
{
    // generic(T) bone structure for all database CRUD operations
    public interface IRepository<T> where T: class, new()
    { 
        // C: Create
        void Create(T entity);

        // D: Deleta
        void Remove(T entity);

        // U: Update
        void Update(T entity);

        // R: Read
        // find and get database object by its id
        T GetById(object id);

        // get list of generic(T) entities
        List<T> GetAll();

        // query type open on database during program running 
        IQueryable<T> GetQueryable();
    }
}

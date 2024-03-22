
namespace Infrastructure.Dal.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Add (T entity);
        void Update (T entity);
        void Delete (Guid id);
        void Save();
        IEnumerable<T> GetAll();


    }
}

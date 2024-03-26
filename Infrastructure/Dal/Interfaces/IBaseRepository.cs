
namespace Infrastructure.Dal.Interfaces
{/// <summary>
 ///Базовый интерфейс CRUD
 /// </summary>
 /// <typeparam name="T"></typeparam>

    public interface IBaseRepository<T>
    {
        void Add (T entity);
        void Update (T entity);
        void Delete (Guid id);
        IEnumerable<T> GetAll();
    }
}

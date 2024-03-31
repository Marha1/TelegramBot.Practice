using Infrastructure.Dal.Interfaces;
namespace Infrastructure.Dal.Repository;

public abstract class BaseRepository<T>:IBaseRepository<T> where T : class
{/// <summary>
 /// Реализация базового интерфейса  CRUD
 /// </summary>
    private readonly AplicationContext _context;
    public BaseRepository(AplicationContext aplicationContext)
    {
        _context = aplicationContext;
    }
    /// <summary>
    /// Добавление 
    /// </summary>
    /// <param name="entity"></param>
    public void Add(T entity)
    {
        _context.AddAsync(entity);
        _context.SaveChanges();
    }
    
    /// <summary>
    ///Обновление объекта при сравнение схожести объекта через переписанный Equals,который использует рефлексию     /// </summary>
     /// <param name="entity"></param>

     public bool Update(T entity)
     {
         // Найти объект в базе данных
         var findEntity = _context.Set<T>().FirstOrDefault(e => e.Equals(entity));
         if (findEntity != null)
         {
             ///Берем значение свойств из базы и задаем ему новые значения из запроса
             _context.Entry(findEntity).CurrentValues.SetValues(entity);
             _context.SaveChanges();
             return true;
         }
         return false;
     }

    /// <summary>
    /// Удаление по id 
    /// </summary>
    /// <param name="id"></param>
    public bool Delete(Guid id)
    {
        var entity= _context.Set<T>().Find(id);
        if (entity==null)
        {
            return false;
        }
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
        return false;
    }
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
}
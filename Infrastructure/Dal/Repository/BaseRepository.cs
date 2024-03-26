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

    public void Update(T entity)
    {
        var result = _context.Set<T>().FirstOrDefault(p => p.Equals(this)== entity.Equals(entity));
        if (result is not null)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
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
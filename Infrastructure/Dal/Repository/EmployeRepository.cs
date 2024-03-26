using Domain.Models;
using Infrastructure.Dal.Interfaces;
namespace Infrastructure.Dal.Repository;
/// <summary>
 /// Реализация расширяющего интерфейса IEmployeRepository
 /// </summary>
    public class EmployeRepository : BaseRepository<Employee>,IEmployeRepository<Employee>
    {
        private readonly AplicationContext _context;
        public EmployeRepository(AplicationContext context):base (context)
        {
            this._context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        
    }


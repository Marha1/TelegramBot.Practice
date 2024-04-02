using Domain.Models;

namespace Application.Services.Interfaces
{
    public interface IEmployeService
    {
        IEnumerable<Employee> GetEmploye();
        void Add(Employee entity);
        bool Update(Employee entity);
        bool Delete(Guid id);
    }
}

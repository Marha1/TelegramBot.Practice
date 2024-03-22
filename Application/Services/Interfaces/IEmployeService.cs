using Domain.Models;

namespace Application.Services.Interfaces
{
    public interface IEmployeService
    {
        IEnumerable<Employee> GetEmploye();
        void Add(Employee entity);
        void Update(Employee entity);
        void Delete(Guid id);
    }
}

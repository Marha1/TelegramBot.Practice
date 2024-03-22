using Application.Services.Interfaces;
using Domain.Models;
using Infrastructure.Dal.Interfaces;

namespace Application.Services.Implementations
{
    public class EmployeService : IEmployeService
    {
        private readonly IBaseRepository<Employee> _employeerepository;
        public EmployeService(IBaseRepository<Employee> employeerepository)
        {
            this._employeerepository = employeerepository;
        }

        public void Add(Employee entity)
        {
            _employeerepository.Add(entity);
           
        }

        public void Delete(Guid id)
        {
            _employeerepository.Delete(id);
               
        }

        public IEnumerable<Employee> GetEmploye()
        {
            var employees = _employeerepository.GetAll();
            return employees;
        }

        public void Update(Employee entity)
        {
            _employeerepository.Update(entity);
        }
    }
}

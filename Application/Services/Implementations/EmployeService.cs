using System.ComponentModel.DataAnnotations;
using Application.Services.Interfaces;
using Domain.Models;
using Domain.Validations;
using FluentValidation.Results;
using Infrastructure.Dal.Interfaces;
using ValidationResult = FluentValidation.Results.ValidationResult;

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
            var validator = new EmployeeValidation();
            ValidationResult validationResult = validator.Validate(entity);

            if (validationResult.IsValid)
            {
                _employeerepository.Add(entity);
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
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

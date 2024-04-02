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

        public bool Delete(Guid id)
        {
            var request=_employeerepository.Delete(id);
            return request;
        }

        public IEnumerable<Employee> GetEmploye()
        {
            var employees = _employeerepository.GetAll();
            return employees;
        }

        public bool Update(Employee entity)
        {
            if (!_employeerepository.Update(entity))
            {
                return false;
            }
            return true;
        }
    }
}

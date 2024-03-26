using System.ComponentModel.DataAnnotations;
using Domain.Validations;
using ValidationException = FluentValidation.ValidationException;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Domain.Models
{
    public class Employee:BaseEntity
    {
        public Employee()
        {
            
        }
        public Employee(string name, DateTime birthDay, string _Post)
        {
            
            var validationResult = Validate();
            if (!validationResult.IsValid)
            {
                string errorMessages = string.Join("\n", validationResult.Errors);
                throw new ValidationException(errorMessages);
            }
            Name= name;
            DateOfBirh = birthDay;
            Post = _Post;
            
        }
        public int Age  
        {
            get => DateTime.Now.Year - DateOfBirh.Year;
            set
            {
                if (value < 18)
                {
                    throw new ValidationException("Возраст сотрудника не может быть меньше 18 лет.");
                }
            }
        }
        public string? Post { get; set; }
        public DateTime DateOfBirh { get; set; }
        public ValidationResult Validate()
        {
            var validator = new EmployeeValidation();
            return validator.Validate(this);
        }
    }
}

using System.ComponentModel.DataAnnotations;
using Domain.Validations;
using ValidationException = FluentValidation.ValidationException;
using ValidationResult = FluentValidation.Results.ValidationResult;


namespace Domain.Models
{
    public class UsersId:BaseEntity
    {
        public UsersId()
        {
            
        }
        public UsersId(string name)
        {
            
            var validationResult = Validate();
            if (!validationResult.IsValid)
            {
                string errorMessages = string.Join("\n", validationResult.Errors);
                throw new ValidationException(errorMessages);
            }
            Name= name;
            
        }
        public ValidationResult Validate()
        {
            var validator = new UserIdValidation();
            return validator.Validate(this);
        }

        public long ChatID { get; set; }
    }
}


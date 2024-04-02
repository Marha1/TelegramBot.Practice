using Domain.Models;
using FluentValidation;
using System;

namespace Domain.Validations
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage(string.Format(ValidationMessages.IsNullOrEmpty, nameof(Employee.Name)))
                .Matches(@"^[a-zа-я]+$").WithMessage(string.Format(ValidationMessages.IsValidString, nameof(Employee.Name)));

            RuleFor(x => x.DateOfBirh)
                .Must(BeValidBirthDay).WithMessage(string.Format(ValidationMessages.ValidAge));
            RuleFor(x => x.DateOfBirh)
                .Must(BeValidCountBirthDay).WithMessage(string.Format(ValidationMessages.ValidDataBirth));
        }

        private bool BeValidBirthDay(DateTime birthDay)
        {
            return (DateTime.Today - birthDay).TotalDays / 365 >= 18;
        }
        private bool BeValidCountBirthDay(DateTime birthDay)
            {
                return (DateTime.Today - birthDay).TotalDays / 365 <= 150;
            }
    }
}
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
                .NotNull().WithMessage("Имя не должно быть пустым")
                .Matches(@"^[a-zа-я]+$").WithMessage("Имя должно содержать только буквы");

            RuleFor(x => x.DateOfBirh)
                .Must(BeValidBirthDay).WithMessage("Возраст сотрудника должен быть больше 18 лет");
            RuleFor(x => x.DateOfBirh)
                .Must(BeValidCountBirthDay).WithMessage("Некорректная дата рождения");
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
using Domain.Models;
using FluentValidation;
using System;

namespace Domain.Validations
{
    public class UserIdValidation : AbstractValidator<UsersId>
    {
        public UserIdValidation()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Имя не должно быть пустым")
                .Matches(@"^[a-zа-я]+$").WithMessage("Имя должно содержать только буквы");
        }
    }
}
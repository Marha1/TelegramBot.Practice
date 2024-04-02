using Domain.Models;
using FluentValidation;
namespace Domain.Validations
{
    public class UserIdValidation : AbstractValidator<UsersId>
    {
        public UserIdValidation()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Имя не должно быть пустым")
                .Matches(@"^[a-zа-я]+$").WithMessage(string.Format(ValidationMessages.IsNullOrEmpty,nameof(UsersId.Name)));
        }
    }
}
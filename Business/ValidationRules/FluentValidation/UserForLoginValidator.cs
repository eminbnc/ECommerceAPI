using Business.Commands.UserCommands;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForLoginValidator:AbstractValidator<UserForLoginCommand>
    {
        public UserForLoginValidator()
        {
            RuleFor(p => p._userForLoginRequest.Email).NotEmpty().EmailAddress();
            RuleFor(p => p._userForLoginRequest.Password)
            .Length(6, 20).WithMessage("Parola alanı 6 ile 20 karakter arasında olmalıdır!");
        }
    }
}

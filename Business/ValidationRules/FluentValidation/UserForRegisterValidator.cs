using Business.Commands.UserCommands;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterValidator: AbstractValidator<UserForRegisterCommand>
    {
        public UserForRegisterValidator()
        {
            RuleFor(p => p._userForRegisterRequest.Email).NotEmpty().EmailAddress();
            RuleFor(p => p._userForRegisterRequest.FirstName)
                .Length(3, 20).WithMessage("İsim alanı 3 ile 20 karakter arasında olmalıdır!");
            RuleFor(p => p._userForRegisterRequest.LastName)
               .Length(2, 40).WithMessage("Soyisim alanı 2 ile 40 karakter arasında olmalıdır!");
            RuleFor(p => p._userForRegisterRequest.Password)
                .Length(6, 20).WithMessage("Parola alanı 6 ile 20 karakter arasında olmalıdır!");


        }
    }
}

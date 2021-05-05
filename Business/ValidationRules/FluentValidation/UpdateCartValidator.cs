
using Business.Commands.CartCommand;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UpdateCartValidator:AbstractValidator<UpdateProductInCartCommand>
    {
        public UpdateCartValidator()
        {
            RuleFor(p => p._cart.Id).NotEmpty();
            RuleFor(p => p._cart.UserId).NotEmpty(); 
            RuleFor(p => p._cart.ProductId).NotEmpty(); 
            RuleFor(p => p._cart.Quantity).NotEmpty().GreaterThan(-1);
        }
    }
}

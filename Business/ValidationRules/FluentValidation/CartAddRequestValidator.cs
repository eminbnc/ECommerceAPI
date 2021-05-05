using Business.Commands.CartCommand;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CartAddRequestValidator:AbstractValidator<UpdateProductToCartCommand>
    {
        public CartAddRequestValidator()
        {
            RuleFor(p => p._cartAddRequest.UserId).NotEmpty().GreaterThan(0);
            RuleFor(p => p._cartAddRequest.ProductId).NotEmpty().GreaterThan(0);
        }
    }
}

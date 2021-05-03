using Business.Commands.ProductCommands;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductAddRequestValidator:AbstractValidator<ProductAddCommand>
    {
        public ProductAddRequestValidator()
        {
            RuleFor(p => p._product.ProductName).NotEmpty();
            RuleFor(p => p._product.ProductName).MinimumLength(2);
            RuleFor(p => p._product.UnitPrice).NotEmpty().GreaterThan(0);
            RuleFor(p => p._product.UnitPrice).GreaterThan(p => p._product.Discount);
            RuleFor(p => p._product.Brand).NotEmpty();
            RuleFor(p => p._product.Description).NotEmpty();
            RuleFor(p => p._product.Stock).NotEmpty().GreaterThan(0);
            RuleFor(p => p._product.Tax).NotEmpty();
            RuleFor(p => p._product.SubCategoryId).NotEmpty();
        }
    }
}

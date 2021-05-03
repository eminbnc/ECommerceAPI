using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;

namespace Business.Commands.ProductCommands
{
    public class ProductUpdateCommand:IRequest<IResult>
    {
        public Product _product { get; set; }
        public ProductUpdateCommand(Product product)
        {
            _product = product;
        }
    }
}

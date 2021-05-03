using Core.Utilities.Results;
using Entities.DTOs.Request;
using MediatR;

namespace Business.Commands.ProductCommands
{
    public class ProductAddCommand:IRequest<IResult>
    {
        public ProductAddRequest _product { get; set; }
      
        public ProductAddCommand(ProductAddRequest product)
        {
            _product = product;
        }
    }
}

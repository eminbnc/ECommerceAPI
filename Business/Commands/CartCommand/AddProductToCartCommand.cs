using Core.Utilities.Results;
using Entities.DTOs.Request;
using MediatR;

namespace Business.Commands.CartCommand
{
    public class UpdateProductToCartCommand:IRequest<IResult>
    {
        public AddProductToCartRequest _cartAddRequest { get; set; }

        public UpdateProductToCartCommand(AddProductToCartRequest cartAddRequest)
        {
            _cartAddRequest = cartAddRequest;
        }
    }
}

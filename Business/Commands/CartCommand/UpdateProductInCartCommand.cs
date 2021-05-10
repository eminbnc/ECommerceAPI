using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;

namespace Business.Commands.CartCommand
{
    public class UpdateProductInCartCommand:IRequest<IResult>
    {
        public Cart _cart { get; set; }
        public UpdateProductInCartCommand(Cart cart)
        {
            _cart = cart;
        }
    }
}

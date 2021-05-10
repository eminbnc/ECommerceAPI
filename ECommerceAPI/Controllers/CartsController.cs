using Business.Commands.CartCommand;
using Business.Queries.CartQueries;
using Entities.Concrete;
using Entities.DTOs.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Adds to the shopping cart or increases the number of items by 1 if the item is in the shopping cart
        /// </summary>
        /// <param name="cartAddRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddToCart(AddProductToCartRequest cartAddRequest)
        {
            var result = await _mediator.Send(new UpdateProductToCartCommand(cartAddRequest));
            return Ok(result);
        }
        /// <summary>
        /// Updating item in the cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateToCart(Cart cart)
        {
            var result = await _mediator.Send(new UpdateProductInCartCommand(cart));
            if (result.Success) return Ok(result);
            return BadRequest(cart);
        }
        /// <summary>
        /// Lists the products in the user's cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetItemsInCart(int userId)
        {
            var result = await _mediator.Send(new GetItemsInCartQuery(userId));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

using Business.Commands.UserCommands;
using Entities.DTOs.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// User Registration Operation
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterForUser(UserForRegisterRequest registerRequest)
        {
            var result = await _mediator.Send(new UserForRegisterCommand(registerRequest));
            if(result.Success) return Ok(result);
            return BadRequest(result);
        }
        /// <summary>
        /// User Login Operation
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginRequest loginRequest)
        {
            var result = await _mediator.Send(new UserForLoginCommand(loginRequest));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        /// <summary>
        /// User Update Operation
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UserUpdate(UserUpdateRequest request)
        {
            var result = await _mediator.Send(new UserForUpdateCommand(request));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

using AutoMapper;
using Business.Commands.UserCommands;
using Entities.DTOs.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public async Task<IActionResult> RegisterForUser(UserForRegisterRequest registerRequest)
        {
            var result = await _mediator.Send(new UserForRegisterCommand(registerRequest));
            if(result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginRequest loginRequest)
        {
            var result = await _mediator.Send(new UserForLoginCommand(loginRequest));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

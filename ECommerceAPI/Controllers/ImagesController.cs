using Business.Commands.ImageCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> SaveImage(IFormFile imageFile)
        {
            var result = await _mediator.Send(new ImageSaveCommand(imageFile));
            if (result.Success) return Ok(result);
            return BadRequest(result);

        }
    }
}

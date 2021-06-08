using Business.Queries.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
       {
            var response = await _mediator.Send(new GetAllCategoryQuery());
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
        [HttpGet("withsubcategories")]
        public async Task<IActionResult> GetCategoriesWithSubCategories()
        {
            var response = await _mediator.Send(new CategoriesWithSubCategorisQuery());
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

    }
}

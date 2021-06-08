using Business.Queries.SubCategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var response = await _mediator.Send(new GetAllSubCategoriesQuery());
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetSubCategoriesByCategoryId(int categoryId)
        {
            var response = await _mediator.Send(new GetSubCategoryByCategoryIdQuery(categoryId));
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }
    }
}

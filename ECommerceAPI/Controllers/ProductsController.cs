﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Business.Queries.ProductQueries;
using Business.Commands.ProductCommands;
using Entities.DTOs.Request;
using Entities.Concrete;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("subcategories/{id}")]
        public async Task<IActionResult> GetProductsBySubcategoryId(int id)
        {
            var result = await _mediator.Send(new GetProductsBySubCategoryQuery(id));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByProductId(int id)
        {
            var result = await _mediator.Send(new GetProductsByIdQuery(id));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("category/{categoryId}/subcategory/{subCategoryId}")]
        public async Task<IActionResult> GetProductsByCategoryWithSubCategory(int categoryId, int subCategoryId)
        {
            var result = await _mediator.Send(new GetProductsByCategoryWithSubCategoryQuery(categoryId, subCategoryId));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductAddRequest product)
        {
            var result = await _mediator.Send(new ProductAddCommand(product));
             return Ok(result);
           
        }
        [HttpPut]
        public async Task<IActionResult> ProductUpdate(Product product)
        {
            var result = await _mediator.Send(new ProductUpdateCommand(product));
            if(result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> ProductDelete(int productId)
        {
            var result = await _mediator.Send(new ProductDeleteCommand(productId));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

    }
}

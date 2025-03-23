using Ecommerce.Application.Commands.ProductCommands;
using Ecommerce.Application.Queries.ProductQueries;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ISender sender) : ControllerBase
    {

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var result = await sender.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute]Guid id)
        {
            var result = await sender.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("GetProductsByCategory/{category}")]
        public async Task<IActionResult> GetProductsByCategoryAsync([FromRoute] CategoryProductEnum category)
        {
            var result = await sender.Send(new GetProductsByCategoryQuery(category));
            return Ok(result);
        }

        [HttpGet("GetProductsByPrice/{price}")]
        public async Task<IActionResult> GetProductsByPriceAsync([FromRoute] decimal price)
        {
            var result = await sender.Send(new GetProductsByPriceQuery(price));
            return Ok(result);
        }

        [HttpGet("GetProductsByBrand/{brandName}")]
        public async Task<IActionResult> GetProductsByBrandAsync([FromRoute] string brandName)
        {
            var result = await sender.Send(new GetProductsByBrandQuery(brandName));
            return Ok(result);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductEntity product)
        {
            var result = await sender.Send(new AddProductCommand(product));
            return Ok(result);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductEntity product)
        {
            var result = await sender.Send(new UpdateProductCommand(product));
            return Ok(result);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new DeleteProductCommand(id));
            return Ok(result);
        }
    }
}

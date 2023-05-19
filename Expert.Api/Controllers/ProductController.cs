using Expert.Api.Base;
using Expert.Core.Interfaces.IServices;
using Expert.Core.Models;
using Expert.Core.Requests;
using Expert.Core.Services.Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expert.Api.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        { 
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<Product>>), 200)]
        [ProducesErrorResponseType(typeof(ApiResponse<object>))]
        public async Task<ActionResult<ApiResponse<List<Product>>>> GetAllProducts()
        {
            var result = await _productService.GetProductsAsync();

            return ApiResponse<List<Product>>.Create(result);
        }

        [HttpGet("byId")]
        [ProducesResponseType(typeof(ApiResponse<Product>), 200)]
        [ProducesErrorResponseType(typeof(ApiResponse<object>))]
        public async Task<ActionResult<ApiResponse<Product>>> GetProduct([FromQuery] string id)
        {
            var result = await _productService.GetProductAsync(id);

            return Ok(ApiResponse<Product>.Create(result));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        [ProducesErrorResponseType(typeof(ApiResponse<object>))]
        public async Task<ActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            var productDto = new ProductDto()
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
            };

            await _productService.AddProductAsync(request.CategoryId, productDto);

            return Ok();
        }
    }
}

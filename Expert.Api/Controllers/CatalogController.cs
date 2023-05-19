using Expert.Api.Base;
using Expert.Core.Interfaces.IServices;
using Expert.Core.Models;
using Expert.Core.Requests;
using Expert.Core.Services.Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expert.Api.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<Catalog>>), 200)]
        [ProducesErrorResponseType(typeof(ApiResponse<object>))]
        public async Task<ActionResult<ApiResponse<List<Catalog>>>> GetAllCatalogs()
        {
            var result = await _catalogService.GetAllCatalogsAsync();

            return ApiResponse<List<Catalog>>.Create(result);
        }

        [HttpGet("WithProducts")]
        [ProducesResponseType(typeof(ApiResponse<Catalog>), 200)]
        [ProducesErrorResponseType(typeof(ApiResponse<object>))]
        public async Task<ActionResult<ApiResponse<Catalog>>> GetCatalogWithProducts([FromQuery] int catalogId)
        {
            var result = await _catalogService.GetCatalogWithProductsAsync(catalogId);

            return ApiResponse<Catalog>.Create(result);
        }

        [HttpGet("byId")]
        [ProducesResponseType(typeof(ApiResponse<Catalog>), 200)]
        [ProducesErrorResponseType(typeof(ApiResponse<object>))]
        public async Task<ActionResult<ApiResponse<Catalog>>> GetProduct([FromQuery] int id)
        {
            var result = await _catalogService.GetCatalogByIdAsync(id);

            return Ok(ApiResponse<Catalog>.Create(result));
        }

        [HttpGet("byName")]
        [ProducesResponseType(typeof(ApiResponse<Catalog>), 200)]
        [ProducesErrorResponseType(typeof(ApiResponse<object>))]
        public async Task<ActionResult<ApiResponse<Catalog>>> GetProduct([FromQuery] string id)
        {
            var result = await _catalogService.GetCatalogByNameAsync(id);

            return Ok(ApiResponse<Catalog>.Create(result));
        }
    }
}

using Expert.Core.Exceptions;
using Expert.Core.Interfaces.IRepositories;
using Expert.Core.Interfaces.IServices;
using Expert.Core.Services.Product.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Expert.Core.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ILogger _logger;
        private readonly IProductsRepository _productsRepository;
        private readonly ICatalogService _catalogService;

        public ProductService(ILogger<ProductService> logger, IProductsRepository productsRepository, ICatalogService catalogService)
        {
            _logger = logger;
            _productsRepository = productsRepository;
            _catalogService = catalogService;
        }
        
        public Task<List<Core.Models.Product>> GetProductsAsync()
        {
            return _productsRepository.AsQueryable().ToListAsync();
        }

        public Task<Core.Models.Product?> GetProductAsync(string id)
        {
            return _productsRepository.GetAsync(id);
        }

        public async Task AddProductAsync(string catalogName, ProductDto product)
        {
            var catalog = await _catalogService.GetCatalogByNameAsync(catalogName);
            if (catalog is null)
            {
                throw new FriendlyException("Product cannot be added to not existing catalog");
            }

            await AddProductAsyncInternal(catalog, product);
        }

        public async Task AddProductAsync(int catalogId, ProductDto product)
        {
            var catalog = await _catalogService.GetCatalogByIdAsync(catalogId);
            if (catalog is null)
            {
                throw new FriendlyException("Product cannot be added to not existing catalog");
            }

            await AddProductAsyncInternal(catalog, product);
        }

        private async Task AddProductAsyncInternal(Core.Models.Catalog catalog, ProductDto product)
        {
            var doesProductExist = await _productsRepository.AsQueryable()
                .Include(prod => prod.Catalog)
                .Where(prod => prod.Name == product.Name && prod.Catalog.Name == catalog.Name)
                .AnyAsync();

            if (doesProductExist)
            {
                throw new FriendlyException("Product with the same name already exists in this catalog");
            }

            var productToAdd = new Core.Models.Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = product.Name,
                Code = product.Code,
                Description = product.Description,
                Price = product.Price,
                Catalog = catalog,
                CatalogId = catalog.Id
            };

            catalog.Products ??= new List<Core.Models.Product>();   

            catalog.Products.Add(productToAdd);
            await _catalogService.UpdateCatalogProductsAsync(catalog);
        }
    }
}

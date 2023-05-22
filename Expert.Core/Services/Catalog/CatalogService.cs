using Expert.Core.Interfaces.IRepositories;
using Expert.Core.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Expert.Core.Services.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly ILogger _logger;
        private readonly ICatalogsRepository _catalogsRepository;
        public CatalogService(ILogger<CatalogService> logger, ICatalogsRepository catalogsRepository)
        {
            _logger = logger;
            _catalogsRepository = catalogsRepository;
        }

        public Task<Core.Models.Catalog?> GetCatalogWithProductsAsync(int id)
        {
            return _catalogsRepository.AsQueryable()
                .Include(e => e.Products)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<Core.Models.Catalog>> GetAllCatalogsAsync()
        {
            return _catalogsRepository.AsQueryable().ToListAsync();
        }

        public Task<Core.Models.Catalog?> GetCatalogByIdAsync(int id)
        {
            if (id < 0)
            {
                throw new System.ArgumentOutOfRangeException(nameof(id), "id property cannot be less than or equal to zero");
            }

            return _catalogsRepository.GetAsync(id);
        }

        public Task<Core.Models.Catalog?> GetCatalogByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentNullException(nameof(name), "name property cannot be null or empty");
            }

            return _catalogsRepository.AsQueryable()
                .FirstOrDefaultAsync(catalog => catalog.Name == name);
        }

        public async Task UpdateCatalogProductsAsync(Core.Models.Catalog? catalog)
        {
            if(catalog is null) 
            { 
                throw new Exception("Tried to update products of null catalog");
            }

            await _catalogsRepository.UpdateAsync(catalog);
            await _catalogsRepository.SaveChangesAsync();
        }
    }
}

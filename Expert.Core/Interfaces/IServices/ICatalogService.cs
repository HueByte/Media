using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Core.Interfaces.IServices
{
    public interface ICatalogService
    {
        Task<List<Models.Catalog>> GetAllCatalogsAsync();
        Task<Models.Catalog?> GetCatalogByIdAsync(int id);
        Task<Models.Catalog?> GetCatalogByNameAsync(string name);
        Task UpdateCatalogProductsAsync(Core.Models.Catalog? catalog);
        Task<Core.Models.Catalog?> GetCatalogWithProductsAsync(int id);
    }
}

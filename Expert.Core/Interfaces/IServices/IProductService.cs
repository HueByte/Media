using Expert.Core.Services.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Core.Interfaces.IServices
{
    public interface IProductService
    {
        Task<List<Core.Models.Product>> GetProductsAsync();
        Task<Core.Models.Product?> GetProductAsync(string id);
        Task AddProductAsync(int catalogId, ProductDto product);
        Task AddProductAsync(string catalogName, ProductDto product);
    }
}

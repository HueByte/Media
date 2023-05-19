using Expert.Core.Abstractions;
using Expert.Core.Interfaces.IRepositories;
using Expert.Core.Models;

namespace Expert.Infrastructure.Repositories
{
    public class ProductsRepository : BaseRepository<string, Product, MediaContext>, IProductsRepository
    {
        public ProductsRepository(MediaContext mediaContext) : base(mediaContext) { }
    }
}

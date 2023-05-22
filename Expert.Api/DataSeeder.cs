using Expert.Core.Interfaces.IRepositories;
using Expert.Core.Models;
using Expert.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Expert.Api
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var context = scope.ServiceProvider.GetRequiredService<MediaContext>();

            await SeedCatalogs(scope);
        }

        private async static Task SeedCatalogs(AsyncServiceScope scope)
        {
            var catalogRepo = scope.ServiceProvider.GetRequiredService<ICatalogsRepository>();

            Random rnd = new();
            
            // generate random amount of catalogs
            int catCount = rnd.Next(3, 10);

            var seedProducts = new List<List<Product>>();
            for (int z = 0; z < catCount; z++)
            {
                List<Product> products = new();
                for (int i = 0; i < rnd.Next(4, 32); i++)
                {
                    products.Add(new Product()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = $"test {i}",
                        Code = $"AA0-[{i}]",
                        Description = $"test des {i}",
                        Price = rnd.Next(0, 400) + Math.Round(new decimal(rnd.NextDouble()), 2),
                    });
                }

                seedProducts.Add(products);
            }

            List<Core.Models.Catalog> catalogs = new();

            foreach((var products, var index) in seedProducts.Select((item, index) => (item,index)))
            {
                Catalog cat = new Catalog()
                {
                    Description = $"Testing Catalog {index}",
                    Name = $"Catalog {index}",
                    Products = products
                };

                catalogs.Add(cat);
            }

            await catalogRepo.AddRangeAsync(catalogs);
            await catalogRepo.SaveChangesAsync();
        }
    }
}

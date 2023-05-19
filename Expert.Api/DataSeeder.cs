using Expert.Core.Interfaces.IRepositories;
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

            List<Core.Models.Catalog> catalogs = new() 
            {
                new Core.Models.Catalog()
                {
                    Description = "Testing Catalog 1",
                    Name = "Catalog 1",
                    Products = new List<Core.Models.Product>()
                    {
                        new Core.Models.Product()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "test",
                            Code = "AA00",
                            Description = "test des",
                            Price = 40.99m,
                        }
                    }
                },
                new Core.Models.Catalog()
                {
                    Description = "Testing Catalog 2",
                    Name = "Catalog 2",
                }
            };

            await catalogRepo.AddRangeAsync(catalogs);
            await catalogRepo.SaveChangesAsync();
        }
    }
}

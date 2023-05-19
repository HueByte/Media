using Expert.Core.Interfaces.IRepositories;
using Expert.Core.Interfaces.IServices;
using Expert.Core.Services.Catalog;
using Expert.Core.Services.Product;
using Expert.Infrastructure;
using Expert.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Expert.Api.Configuration
{
    public static class ApiConfigurator
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // services
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IProductService, ProductService>();


            // repositories
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ICatalogsRepository, CatalogsRepository>();

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {


            return services;
        }

        public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("MediaContext");
            
            if (string.IsNullOrEmpty(connString))
                throw new Exception("Database connection string to MediaContext cannot be empty");

            services.AddMediaDbContext(connString);

            return services;
        }
    }
}

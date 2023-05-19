using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Infrastructure
{
    public static class Setup
    {
        public static IServiceCollection AddMediaDbContext(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<MediaContext>(options =>
            {
                //options.UseSqlite(connectionString, 
                //    x => x.MigrationsAssembly(typeof(MediaContext).Assembly.GetName().Name));
                
                options.UseInMemoryDatabase("Media");
            });

            return services;
        }
    }
}

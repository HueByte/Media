using Expert.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Infrastructure
{
    public class MediaContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public MediaContext() { }
        public MediaContext(DbContextOptions<MediaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Catalog>()
                .HasMany(e => e.Products)
                .WithOne(e => e.Catalog)
                .HasForeignKey(e => e.CatalogId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasOne(e => e.Catalog)
                .WithMany(e => e.Products);

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Product> Products => Set<Product>();
        public virtual DbSet<Catalog> Catalogs => Set<Catalog>();
    }
}

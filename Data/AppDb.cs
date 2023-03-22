using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EfAPI.Data
{
    public class AppDb : IdentityDbContext
    {
        public AppDb(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Images> Images { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>(t => t.HasKey(
                ot => new { ot.IdProduct, ot.IdImage }));
            base.OnModelCreating(modelBuilder);
        }
        public class User
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}

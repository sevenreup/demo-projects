using Microsoft.EntityFrameworkCore;
using ProductApi.Entities;

namespace ProductApi.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options)
                : base(options)
        {}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product() {
                Id = 1,
                Name = "Blue Shirt",
                Category = "Shirt",
                Description = "",
                Price = 5000
            }, new Product()
            {
                Id = 2,
                Name = "Green Shirt",
                Category = "Shirt",
                Description = "",
                Price = 8000
            }, new Product()
            {
                Id = 3,
                Name = "Blue Pants",
                Category = "Pants",
                Description = "",
                Price = 12000
            });
        }
        }
}

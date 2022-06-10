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
    }
}

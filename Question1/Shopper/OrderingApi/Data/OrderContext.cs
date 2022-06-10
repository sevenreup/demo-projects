using Microsoft.EntityFrameworkCore;
using OrderingApi.Entities;

namespace OrderingApi.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(new Order()
            {
                Id = 1,
                FirstName = "Jeff",
                LastName = "Maliko",
                UserName = "jeff",
                EmailAddress = "mail.com",

            });

        }
    }
}

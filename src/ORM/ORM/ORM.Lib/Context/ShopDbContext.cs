using Microsoft.EntityFrameworkCore;
using ORM.Lib.Entities;

namespace ORM.Lib.Context
{
    public sealed class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {
            Database.EnsureCreated();
        }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}

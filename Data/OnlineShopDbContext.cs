using Microsoft.EntityFrameworkCore;
using OnlineShopAPI.Models;

namespace OnlineShopAPI.Data
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}

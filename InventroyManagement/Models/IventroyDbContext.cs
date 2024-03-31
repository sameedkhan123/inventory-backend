using Microsoft.EntityFrameworkCore;

namespace InventroyManagement.Models
{
    public class IventroyDbContext:DbContext
    {
        public IventroyDbContext(DbContextOptions<IventroyDbContext>options):base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}

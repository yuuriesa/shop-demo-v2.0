using Microsoft.EntityFrameworkCore;
using ShopDemo.Models;

namespace ShopDemo.Data
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public DbSet<Customer> Customers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public ApplicationDbContext(DbContextOptions options) : base(options: options)
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=127.0.0.1;Database=ShopDemoV2.0;User=SA;Password=Password123!;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString: connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
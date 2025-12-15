using Microsoft.EntityFrameworkCore;
using ShopDemo.Models;

namespace ShopDemo.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public int SaveChanges();
    }
}
using Microsoft.EntityFrameworkCore;
using ShopDemo.Models;

namespace ShopDemo.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;

namespace ShopDemo.Data
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options: options)
        {
            
        }
    }
}
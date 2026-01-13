using Microsoft.EntityFrameworkCore;
using ShopDemo.Data;
using ShopDemo.Models;

namespace ShopDemo.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext= dbContext;
        }

        public Customer? GetCustomerByEmail(string emailAddress)
        {
            // add include depois que colocar os endereços
            Customer? customer = _dbContext.Customers.AsNoTracking().Where(c => c.EmailAddress == emailAddress).FirstOrDefault();

            if (customer == null)
            {
                return null;
            }

            return customer;
        }
    }
}
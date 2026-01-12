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

        public Customer GetCustomerByEmail(string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
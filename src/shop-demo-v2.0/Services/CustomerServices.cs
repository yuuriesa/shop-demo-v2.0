using ShopDemo.Data;
using ShopDemo.Repository;

namespace ShopDemo.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _repository;
        private readonly ApplicationDbContext _dbContext;

        public CustomerServices(ICustomerRepository repository, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _repository = repository;   
        }
    }
}
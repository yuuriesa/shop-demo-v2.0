using ShopDemo.Data;
using ShopDemo.DTOs;
using ShopDemo.Models;
using ShopDemo.Repository;
using ShopDemo.Utils;

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

        public Customer Add(CustomerRequestDTO customerRequestDTO)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> GetAll(PaginationFilter paginationFilter)
        {
            return _repository.GetAll(paginationFilter: paginationFilter);
        }
    }
}
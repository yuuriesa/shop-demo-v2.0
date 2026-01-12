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
            Customer newCustomer = Customer.RegisterNew
            (
                    firstName: customerRequestDTO.FirstName,
                    lastName: customerRequestDTO.LastName,
                    emailAddress: customerRequestDTO.EmailAddress,
                    dateOfBirth: customerRequestDTO.DateOfBirth
            );

            if (!newCustomer.IsValid)
            {
                throw new ArgumentOutOfRangeException($"Mano ta errado isso ai: {newCustomer.ErrorMessagesIfNotValid}");
            }

            _repository.Add(entity: newCustomer);
            _repository.SaveChanges();

            return newCustomer;

        }

        public IQueryable<Customer> GetAll(PaginationFilter paginationFilter)
        {
            return _repository.GetAll(paginationFilter: paginationFilter);
        }
    }
}
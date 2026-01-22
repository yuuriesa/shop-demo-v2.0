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

        public ServiceResult<Customer> Add(CustomerRequestDTO customerRequestDTO)
        {
            Customer? customerExists = _repository.GetCustomerByEmail(emailAddress: customerRequestDTO.EmailAddress);

            if (customerExists != null)
            {
                return ServiceResult<Customer>.ErrorResult
                (
                    message: $"{DomainResponseMessages.CustomerEmailExistsError}: {customerRequestDTO.EmailAddress}",
                    statusCode: 409
                );
            }

            Customer newCustomer = Customer.RegisterNew
            (
                    firstName: customerRequestDTO.FirstName,
                    lastName: customerRequestDTO.LastName,
                    emailAddress: customerRequestDTO.EmailAddress,
                    dateOfBirth: customerRequestDTO.DateOfBirth
            );

            if (!newCustomer.IsValid)
            {
                return ServiceResult<Customer>.ErrorResult(message: newCustomer.ErrorMessagesIfNotValid, statusCode: 400);
            }

            _repository.Add(entity: newCustomer);
            _repository.SaveChanges();

            return ServiceResult<Customer>.SuccessResult(data: newCustomer);

        }

        public CustomerResponseDTO GenerateCustomerResponseDTO(Customer customer)
        {
            CustomerResponseDTO customerRespondeDTO = new CustomerResponseDTO
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress,
                DateOfBirth = customer.DateOfBirth  
            };

            return customerRespondeDTO;
        }

        public List<CustomerResponseDTO> GenerateListCustomerResponseDTO(IQueryable<Customer> customers)
        {
            List<CustomerResponseDTO> listCustomersResponseDTOs = new List<CustomerResponseDTO>();

            foreach (var customer in customers)
            {
                CustomerResponseDTO customerResponseDTO = new CustomerResponseDTO
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    EmailAddress = customer.EmailAddress,
                    DateOfBirth = customer.DateOfBirth  
                };

                listCustomersResponseDTOs.Add(item: customerResponseDTO);
            };

            return listCustomersResponseDTOs;
        }

        public IQueryable<Customer> GetAll(PaginationFilter paginationFilter)
        {
            return _repository.GetAll(paginationFilter: paginationFilter);
        }

        public Customer GetById(int id)
        {
            return _repository.GetById(id: id);
        }
    }
}
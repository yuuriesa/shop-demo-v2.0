using Microsoft.EntityFrameworkCore;
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
            CustomerResponseDTO customerResponseDTO = new CustomerResponseDTO
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress,
                DateOfBirth = customer.DateOfBirth  
            };

            return customerResponseDTO;
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

        public ServiceResult<Customer> Update(int id, CustomerRequestDTO customerRequestDTO)
        {
            Customer? customerExists = _dbContext.Customers.AsNoTracking().Where(c => c.CustomerId == id).FirstOrDefault();

            if (customerExists == null)
            {
                return ServiceResult<Customer>.ErrorResult
                (
                    message: DomainResponseMessages.CustomerNotFoundError,
                    statusCode: 404
                );
            }

            // Lógica: o email passado existe ? se sim, ele pertence ao mesmo id do customer que passei? se sim, deixa passar, afinal é o mesmo customer repetindo o email.
            // Agora, se o email existe, e ele NÃO pertence ao customer com o mesmo id, NEGA!
            Customer? customerEmailExists = _repository.GetCustomerByEmail(emailAddress: customerRequestDTO.EmailAddress);

            if (customerEmailExists != null && customerEmailExists.CustomerId != id)
            {
                return ServiceResult<Customer>.ErrorResult
                (
                    message: $"{DomainResponseMessages.CustomerEmailExistsError}: {customerRequestDTO.EmailAddress}",
                    statusCode: 409
                );
            }

            Customer updateCustomer = Customer.SetExistingInfo
            (
                customerId: customerExists.CustomerId,
                firstName: customerRequestDTO.FirstName,
                lastName: customerRequestDTO.LastName,
                emailAddress: customerRequestDTO.EmailAddress,
                dateOfBirth: DateOnly.FromDateTime(customerRequestDTO.DateOfBirth)
            );

            if (!updateCustomer.IsValid)
            {
                return ServiceResult<Customer>.ErrorResult(message: updateCustomer.ErrorMessagesIfNotValid, statusCode: 400);
            }

            _repository.Update(id: id, entity: updateCustomer);
            _repository.SaveChanges();

            return ServiceResult<Customer>.SuccessResult(data: updateCustomer);
        }

        public ServiceResult<Customer> UpdatePatch(int id, CustomerRequestDTOToUpdatePatch customerRequestDTOToUpdatePatch)
        {
            Customer? customerExists = _dbContext.Customers.AsNoTracking().Where(c => c.CustomerId == id).FirstOrDefault();

            if (customerExists == null)
            {
                return ServiceResult<Customer>.ErrorResult
                (
                    message: DomainResponseMessages.CustomerNotFoundError,
                    statusCode: 404
                );
            }

            // Lógica: o email passado existe ? se sim, ele pertence ao mesmo id do customer que passei? se sim, deixa passar, afinal é o mesmo customer repetindo o email.
            // Agora, se o email existe, e ele NÃO pertence ao customer com o mesmo id, NEGA!
            if (customerRequestDTOToUpdatePatch.EmailAddress.Length > 1)
            {
                Customer? customerEmailExists = _repository.GetCustomerByEmail(emailAddress: customerRequestDTOToUpdatePatch.EmailAddress);

                if (customerEmailExists != null && customerEmailExists.CustomerId != id)
                {
                    return ServiceResult<Customer>.ErrorResult
                    (
                        message: $"{DomainResponseMessages.CustomerEmailExistsError}: {customerRequestDTOToUpdatePatch.EmailAddress}",
                        statusCode: 409
                    );
                }
            }

            string firstNameIfNotExists;
            string lastNameIfNotExists;
            
            

            Customer updateCustomer = Customer.SetExistingInfo
            (
                customerId: customerExists.CustomerId,
                firstName: customerRequestDTO.FirstName,
                lastName: customerRequestDTO.LastName,
                emailAddress: customerRequestDTO.EmailAddress,
                dateOfBirth: DateOnly.FromDateTime(customerRequestDTO.DateOfBirth)
            );

            if (!updateCustomer.IsValid)
            {
                return ServiceResult<Customer>.ErrorResult(message: updateCustomer.ErrorMessagesIfNotValid, statusCode: 400);
            }

            _repository.Update(id: id, entity: updateCustomer);
            _repository.SaveChanges();

            return ServiceResult<Customer>.SuccessResult(data: updateCustomer);
        }
    }
}
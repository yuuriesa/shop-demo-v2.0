using ShopDemo.DTOs;
using ShopDemo.Models;
using ShopDemo.Utils;

namespace ShopDemo.Services
{
    public interface ICustomerServices
    {
        public IQueryable<Customer> GetAll(PaginationFilter paginationFilter);
        public ServiceResult<Customer> Add(CustomerRequestDTO customerRequestDTO);
        public CustomerResponseDTO GenerateCustomerResponseDTO(Customer customer);
    }
}
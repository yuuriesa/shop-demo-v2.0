using ShopDemo.DTOs;
using ShopDemo.Models;
using ShopDemo.Utils;

namespace ShopDemo.Services
{
    public interface ICustomerServices
    {
        public IQueryable<Customer> GetAll(PaginationFilter paginationFilter);
        public Customer GetById(int id);
        public ServiceResult<Customer> Add(CustomerRequestDTO customerRequestDTO);
        public ServiceResult<Customer> Update(int id, CustomerRequestDTO customerRequestDTO);
        public ServiceResult<Customer> UpdatePatch(int id, CustomerRequestDTOToUpdatePatch customerRequestDTOToUpdatePatch);
        public void Remove(int id);
        public CustomerResponseDTO GenerateCustomerResponseDTO(Customer customer);
        public List<CustomerResponseDTO> GenerateListCustomerResponseDTO(IQueryable<Customer> customers);
    }
}
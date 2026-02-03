using Microsoft.AspNetCore.Mvc;
using ShopDemo.Data;
using ShopDemo.DTOs;
using ShopDemo.Models;
using ShopDemo.Services;
using ShopDemo.Utils;

namespace ShopDemo.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICustomerServices _services;

        public CustomerController(ApplicationDbContext dbContext, ICustomerServices services)
        {
            _dbContext = dbContext;
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber < 0 || pageSize < 0) return BadRequest(DomainResponseMessages.CustomerPaginationError);

            PaginationFilter paginationFilter = new PaginationFilter(pageNumber: pageNumber, pageSize: pageSize);

            IQueryable<Customer> customers = _services.GetAll(paginationFilter: paginationFilter);

            if (customers.Count() == 0)
            {
                return NoContent();
            }

            List<CustomerResponseDTO> customersResponseDTOs = _services.GenerateListCustomerResponseDTO(customers: customers);

            return Ok(customersResponseDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Customer? customer = _services.GetById(id: id);

            if (customer == null)
            {
                return NotFound(DomainResponseMessages.CustomerNotFoundError);
            }

            CustomerResponseDTO customerResponseDTO = _services.GenerateCustomerResponseDTO(customer: customer);

            return Ok(customerResponseDTO);
        }

        [HttpPost]
        public IActionResult Add(CustomerRequestDTO customerRequestDTO)
        {
            ServiceResult<Customer> result = _services.Add(customerRequestDTO: customerRequestDTO);

            if (!result.Success)
            {
                return StatusCode(statusCode: result.StatusCode, value: result.Message);
            }

            CustomerResponseDTO customerResponseDTO = _services.GenerateCustomerResponseDTO(customer: result.Data);

            return CreatedAtAction(actionName: nameof(GetById), routeValues: new { id = customerResponseDTO.CustomerId}, value: customerResponseDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CustomerRequestDTO customerRequestDTO)
        {
            ServiceResult<Customer> result = _services.Update(id: id, customerRequestDTO: customerRequestDTO);

            if (!result.Success)
            {
                return StatusCode(statusCode: result.StatusCode, value: result.Message);
            }

            CustomerResponseDTO customerResponseDTO = _services.GenerateCustomerResponseDTO(customer: result.Data);

            return Ok(customerResponseDTO);
        }
    }
}
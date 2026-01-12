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

            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Add(CustomerRequestDTO customerRequestDTO)
        {
            Customer newCustomer = _services.Add(customerRequestDTO: customerRequestDTO);
            return Ok(newCustomer);
        }
    }
}
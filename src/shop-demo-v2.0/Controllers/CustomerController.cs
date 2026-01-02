using Microsoft.AspNetCore.Mvc;
using ShopDemo.Data;
using ShopDemo.Services;

namespace ShopDemo.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICustomerServices _services;
    }
}
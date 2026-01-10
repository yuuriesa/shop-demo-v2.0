using ShopDemo.Models;
using ShopDemo.Utils;

namespace ShopDemo.Services
{
    public interface ICustomerServices
    {
        public IQueryable<Customer> GetAll(PaginationFilter paginationFilter);
    }
}
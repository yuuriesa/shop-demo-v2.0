using ShopDemo.Models;

namespace ShopDemo.Repository
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        public Customer GeyCustomerByEmail(string emailAddress);
    }
}
namespace ShopDemo.DTOs
{
    public class CustomerRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
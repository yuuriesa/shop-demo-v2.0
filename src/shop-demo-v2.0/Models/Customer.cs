namespace ShopDemo.Models
{
    public class Customer
    {
        // private properties
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private DateOnly _dateOfBirth;

        // public properties
        public int CustomerId { get; private set; }
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public string EmailAddress => _emailAddress;
        public DateOnly DateOfBirth =>  _dateOfBirth;
        public bool IsValid { get; private set; }
        public string ErrorMessagesIfNotValid { get; private set; } = string.Empty;

        // constructors
        private Customer()
        {
            
        }

        private Customer
        (
            int customerId,
            string firstName,
            string lastName,
            string EmailAddress,
            DateOnly dateOfBirth
        )
        {
            
        }

        // public methods
        public static Customer RegisterNew
        (
            string firstName,
            string lastName,
            string emailAddress,
            DateTime dateOfBirth
        )
        {
            
        }

        public static Customer SetExistingInfo
        (
            int customerId,
            string firstName,
            string lastName,
            string emailAddress,
            DateOnly dateOfBirth
        )
        {
            
        }

        // private methods
        private void SetCustomerId(int customerId)
        {
            
        }

        private void SetFisrtName(string firstName)
        {
            
        }

        private void SetLastName(string lastName)
        {
            
        }

        private void SetEmailAddress(string emailAddress)
        {
            
        }
    }
}
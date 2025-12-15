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
            string emailAddress,
            DateOnly dateOfBirth
        )
        {
            SetCustomerId(customerId: customerId);
            _firstName = firstName;
            _lastName = lastName;
            _emailAddress = emailAddress;
            _dateOfBirth = dateOfBirth;

            Validate();
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
            Customer customer = new Customer ();

            customer.SetFisrtName(firstName: firstName);
            customer.SetLastName(lastName: lastName);
            customer.SetEmailAddress(emailAddress: emailAddress);
            customer.SetDateOfBirth(dateOfBirth: dateOfBirth);
            customer.Validate();

            return customer;
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
            Customer customer = new Customer
            (
                customerId: customerId,
                firstName: firstName,
                lastName: lastName,
                emailAddress: emailAddress,
                dateOfBirth: dateOfBirth
            );

            return customer;
        }

        // private methods
        private void SetCustomerId (int customerId)
        {
            CustomerId = customerId;
        }

        private void SetFisrtName (string firstName)
        {
            _firstName = firstName;
        }

        private void SetLastName (string lastName)
        {
            _lastName = lastName;
        }

        private void SetEmailAddress (string emailAddress)
        {
            _emailAddress = emailAddress;
        }

        private void SetDateOfBirth (DateTime dateOfBirth)
        {
            _dateOfBirth = DateOnly.FromDateTime(dateTime: dateOfBirth);
        }

        private void Validate ()
        {
            DateTime dateNow = DateTime.Now;

            if (_dateOfBirth.ToDateTime(TimeOnly.MinValue).ToUniversalTime().Date > dateNow.Date)
            {
                IsValid = false;
                ErrorMessagesIfNotValid = "You cannot put the date with the day after today.";
            }

            if (_firstName.Length > 40)
            {
                IsValid = false;
                ErrorMessagesIfNotValid = "First name must have a maximum of 40 characters";
            }

            if (_lastName.Length > 40)
            {
                IsValid = false;
                ErrorMessagesIfNotValid = "Last name must have a maximum of 40 characters";
            }

            if (ErrorMessagesIfNotValid == string.Empty)
            {
                IsValid = true;
            }
        }
    }
}
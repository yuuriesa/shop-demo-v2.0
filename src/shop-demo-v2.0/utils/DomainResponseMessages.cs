namespace ShopDemo.Utils
{
    public class DomainResponseMessages
    {
        //Customer class
        public const string MaximumOf40CharactersError = "Must have a maximum of 40 characters";
        public const string DateOfBirthError = "You cannot put the date with the day after today.";
        public const string DateOfBirthIsRequired = "Date Of Birth Is Required";
        public const string CustomerPaginationError = "The pagination parameters 'pageSize' and 'pageNumber' must be positive numbers. Check the values provided.";
        public const string CustomerFirstNameIsRequiredError = "First Name Is Required";
        public const string CustomerLastNameIsRequiredError = "Last Name Is Required";
        public const string CustomerEmailAddressIsRequiredError = "Email Address Is Required";
        public const string CustomerEmailFieldIsNotAValid = "The Email field is not a valid e-mail address.";
        public const string CustomerEmailExistsError = "this email exists";
        public const string CustomerNotFoundError = "Customer not found";
        public const string CustomerIdMustBeGeaterThanZeroError = "CustomerId must be greater than zero";
        public const string CustomerFieldsAreInvalidError = "FirstName, Lastname or DateOfBirth fields are invalid, check the values available.";
        public const string DuplicateEmailError = "Found duplicate emails.";
    
        // Address class
        public const string MaximumOf20CharactersError = "Must have a maximum of 20 characters";
        public const string MaximumOf100CharactersError = "Must have a maximum of 100 characters";
        public const string MaximumOf50CharactersError = "Must have a maximum of 50 characters";
    }
}
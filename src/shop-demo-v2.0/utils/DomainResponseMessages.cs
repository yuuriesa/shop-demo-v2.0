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
        public const string MustHaveAtLeastOneAddressError = "You must have at least one address";
        public const string ZipCodeIsRequiredError = "ZipCode Is Required";
        public const string StreetIsRequiredError = "Street Is Required";
        public const string NumberIsRequiredError = "Number Is Required";
        public const string NeighborhoodIsRequired = "Neighborhood Is Required";
    
        // Product class
        public const string ProductIdMustBeGreaterThanZeroError = "ProductId must be greater than zero";
        public const string ProductNotFoundMessageError = "Product not found";
        public const string CodeIsRequired = "Code Is Required";
        public const string ProductCodeExistsError = "This Code Exists";
        public const string ProductNameIsRequired = "ProductName Is Required";
        public const string DuplicateCodeError = "Found duplicate Codes";
        public const string ProductFieldsAreInvalidError = "Code or Name fields are invalid, check the values available.";

        // Order class
        public const string OrderIdMustBeGreaterThanZeroError = "OrderId must be greater than zero";
        public const string OrderNumberMustBeGreaterThanZeroError = "OrderNumber must be greater than zero";
        public const string OrderNumberIsRequired = "OrderNumber Is Required";
        public const string OrderNotFoundMessageError = "Order Not Found";
        public const string OrderNumberExistsError = "This OrderNumber exists";
        public const string OrderNumberNotExistsError = "this OrderNumber not exists";
        public const string DateOfOrderError = "You cannot put the date with the day after today.";
        public const string TheOrderMustHaveAtLeastOneItem = "The order must have at least one item";
        public const string TheUnitValueMustBeGreaterThanZero = "The unit value must be greater than zero.";
        public const string TheQuantityOfItensMustBeGreaterThanZero = "The quantity of itens must be greater than zero.";
        public const string CustomerOrderFieldsAreInvalidError = "FirstName or LastName or OrderDate fields are invalid, check the values available.";
    }
}
namespace ShopDemo.Utils
{
    public class DomainResponseMessages
    {
        //Customer class
        public const string MaximumOf40CharactersError = "Must have a maximum of 40 characters";
        public const string DateOfBirthError = "You cannot put the date with the day after today.";
        public const string CustomerPaginationError = "The pagination parameters 'pageSize' and 'pageNumber' must be positive numbers. Check the values provided.";
        public const string CustomerFirstNameIsRequiredError = "First Name Is Required";
        public const string CustomerLastNameIsRequiredError = "Last Name Is Required";
        public const string CustomerEmailAddressIsRequiredError = "Email Address Is Required";
        public const string CustomerEmailFieldIsNotAValid = "The Email field is not a valid e-mail address.";
    }
}
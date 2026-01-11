namespace ShopDemo.Utils
{
    public class DomainResponseMessages
    {
        public const string MaximumOf40CharactersError = "Must have a maximum of 40 characters";
        public const string DateOfBirthError = "You cannot put the date with the day after today.";
        public const string CustomerPaginationError = "The pagination parameters 'pageSize' and 'pageNumber' must be positive numbers. Check the values provided.";
        public const string CustomerFirstNameIsRequired = "FirstName Is Required";
    }
}
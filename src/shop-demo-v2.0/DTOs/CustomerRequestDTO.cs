using System.ComponentModel.DataAnnotations;
using ShopDemo.Utils;

namespace ShopDemo.DTOs
{
    public class CustomerRequestDTO
    {
        [Required(ErrorMessage = DomainResponseMessages.CustomerFirstNameIsRequiredError)]
        [MaxLength(length: CustomerConstantsRules.MAXIMUM_CHARACTERS_FIRST_NAME, ErrorMessage = DomainResponseMessages.MaximumOf40CharactersError)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.CustomerLastNameIsRequiredError)]
        [MaxLength(length: CustomerConstantsRules.MAXIMUM_CHARACTERS_LAST_NAME, ErrorMessage = DomainResponseMessages.MaximumOf40CharactersError)]
        public string LastName { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.CustomerEmailAddressIsRequiredError)]
        [EmailAddress(ErrorMessage = DomainResponseMessages.CustomerEmailFieldIsNotAValid)]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.DateOfBirthIsRequired)]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
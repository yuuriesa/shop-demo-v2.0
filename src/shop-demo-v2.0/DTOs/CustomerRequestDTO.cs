using System.ComponentModel.DataAnnotations;
using ShopDemo.Utils;

namespace ShopDemo.DTOs
{
    public class CustomerRequestDTO
    {
        [Required(ErrorMessage = DomainResponseMessages.CustomerFirstNameIsRequired)]
        [MaxLength(length: CustomerConstantsRules.MAXIMUM_CHARACTERS_FIRST_NAME, ErrorMessage = DomainResponseMessages.MaximumOf40CharactersError)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.CustomerLastNameIsRequired)]
        [MaxLength(length: CustomerConstantsRules.MAXIMUM_CHARACTERS_LAST_NAME, ErrorMessage = DomainResponseMessages.MaximumOf40CharactersError)]
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
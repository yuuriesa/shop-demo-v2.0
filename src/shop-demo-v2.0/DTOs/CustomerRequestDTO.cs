using System.ComponentModel.DataAnnotations;
using ShopDemo.Utils;

namespace ShopDemo.DTOs
{
    public class CustomerRequestDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = DomainResponseMessages.CustomerFirstNameIsRequired)]
        [MaxLength(length: CustomerConstantsRules.MAXIMUM_CHARACTERS_FIRST_NAME, ErrorMessage = DomainResponseMessages.MaximumOf40CharactersError)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
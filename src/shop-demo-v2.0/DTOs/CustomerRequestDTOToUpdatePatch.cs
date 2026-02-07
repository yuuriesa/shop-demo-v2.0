using System.ComponentModel.DataAnnotations;
using ShopDemo.Utils;

namespace ShopDemo.DTOs
{
    public class CustomerRequestDTOToUpdatePatch
    {
        [MaxLength(length: CustomerConstantsRules.MAXIMUM_CHARACTERS_FIRST_NAME, ErrorMessage = DomainResponseMessages.MaximumOf40CharactersError)]
        public string? FirstName { get; set; }
        [MaxLength(length: CustomerConstantsRules.MAXIMUM_CHARACTERS_LAST_NAME, ErrorMessage = DomainResponseMessages.MaximumOf40CharactersError)]
        public string? LastName { get; set; }
        [EmailAddress(ErrorMessage = DomainResponseMessages.CustomerEmailFieldIsNotAValid)]
        public string? EmailAddress { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
    }
}
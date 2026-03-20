using System.ComponentModel.DataAnnotations;
using ShopDemo.Utils;

namespace ShopDemo.DTOs
{
    public class AddressRequestDTO
    {
        [Required(ErrorMessage = DomainResponseMessages.ZipCodeIsRequiredError)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.StreetIsRequiredError)]
        public string Street { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Neighborhood { get; set; }
        [Required]
        public string AddressComplement { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }  
    }
}
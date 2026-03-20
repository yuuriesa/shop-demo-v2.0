using System.ComponentModel.DataAnnotations;
using ShopDemo.Utils;

namespace ShopDemo.DTOs
{
    public class AddressRequestDTO
    {
        [Required(ErrorMessage = DomainResponseMessages.ZipCodeIsRequiredError)]
        [MaxLength(length: 20, ErrorMessage = DomainResponseMessages.MaximumOf20CharactersError)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.StreetIsRequiredError)]
        [MaxLength(length: 100, ErrorMessage = DomainResponseMessages.MaximumOf100CharactersError)]
        public string Street { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.NumberIsRequiredError)]
        public int Number { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.NeighborhoodIsRequiredError)]
        [MaxLength(length: 50, ErrorMessage = DomainResponseMessages.MaximumOf50CharactersError)]
        public string Neighborhood { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.AddressComplementIsRequiredError)]
        [MaxLength(length: 100, ErrorMessage = DomainResponseMessages.MaximumOf100CharactersError)]
        public string AddressComplement { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.CityIsRequiredError)]
        [MaxLength(length: 50, ErrorMessage = DomainResponseMessages.MaximumOf50CharactersError)]
        public string City { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.StateIsRequiredError)]
        [MaxLength(length: 50, ErrorMessage = DomainResponseMessages.MaximumOf50CharactersError)]
        public string State { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.CountryIsRequiredError)]
        [MaxLength(length: 50, ErrorMessage = DomainResponseMessages.MaximumOf50CharactersError)]
        public string Country { get; set; }  
    }
}
using System.ComponentModel.DataAnnotations;
using ShopDemo.Utils;

namespace ShopDemo.DTOs
{
    public class AddressRequestDTO
    {
        [Required(ErrorMessage = DomainResponseMessages.ZipCodeIsRequiredError)]
        [MaxLength(length: 20, ErrorMessage = DomainResponseMessages.The_ZipCode_Property_Needs_To_Be_At_Least_20_Characters_Long)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.StreetIsRequiredError)]
        public string Street { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.NumberIsRequiredError)]
        public int Number { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.NeighborhoodIsRequiredError)]
        public string Neighborhood { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.AddressComplementIsRequiredError)]
        public string AddressComplement { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.CityIsRequiredError)]
        public string City { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.StateIsRequiredError)]
        public string State { get; set; }
        [Required(ErrorMessage = DomainResponseMessages.CountryIsRequiredError)]
        public string Country { get; set; }  
    }
}
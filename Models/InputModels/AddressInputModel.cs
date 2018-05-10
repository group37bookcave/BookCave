using System.ComponentModel.DataAnnotations;

namespace BookCave.Repositories
{
    public class AddressInputModel
    {
        [Required(ErrorMessage="Please add street.")]
        public string Street { get; set; }

        [Required(ErrorMessage="Please add ZipCode.")]
        public string Zipcode { get; set; }
        
        [Required(ErrorMessage="Please add city.")]
        public string City { get; set; }
        
        [Required(ErrorMessage="Please select Country.")]
        public int CountryId { get; set; }
    }
}
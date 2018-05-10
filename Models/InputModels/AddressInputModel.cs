using System.ComponentModel.DataAnnotations;


namespace BookCave.Repositories
{
    public class AddressInputModel
    {

        [Required(ErrorMessage="Please enter street.")]
        public string Street { get; set; }

        [Required(ErrorMessage="Please enter ZipCode.")]
        public string Zipcode { get; set; }
        [Required(ErrorMessage="Please enter city.")]   
        public string City { get; set; }
        [Required(ErrorMessage="Please select country.")]

        public int CountryId { get; set; }
    }
}
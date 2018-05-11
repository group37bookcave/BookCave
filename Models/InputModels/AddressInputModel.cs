using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace BookCave.Models.InputModels
{
    public class AddressInputModel
    {
        [Required(ErrorMessage="Please enter street.")]

        public string BillingStreet { get; set; }

        [Required(ErrorMessage = "Please enter ZipCode.")]
        public string BillingZipcode { get; set; }
        [Required(ErrorMessage="Please enter city.")]   
        public string BillingCity { get; set; }
        
        [Required(ErrorMessage="Please select country.")]

        public int? BillingCountryId { get; set; }

        [Required(ErrorMessage="Please enter street.")]

        public string Street { get; set; }


        [Required(ErrorMessage = "Please enter ZipCode.")]
        public string Zipcode { get; set; }
        
        [Required(ErrorMessage="Please enter city.")]   
        public string City { get; set; }
        
        [Required(ErrorMessage="Please select country.")]
        
         public int? CountryId { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class AddressInputModel
    {

    /*
        [Required(ErrorMessage = "Please enter ZipCode.")]
        [Required(ErrorMessage="Please enter street.")]

        public string BillingStreet { get; set; }

        public string BillingZipCode { get; set; }
        [Required(ErrorMessage="Please enter city.")]   
        public string BillingCity { get; set; }
        //[Required(ErrorMessage="Please select country.")]

        //public Country BillingCountryId { get; set; }

        [Required(ErrorMessage="Please enter street.")]

        public string ShippingStreet { get; set; }

        public string ShippingZipCode { get; set; }
        [Required(ErrorMessage="Please enter city.")]   
        public string ShippingCity { get; set; }
        //   [Required(ErrorMessage="Please select country.")]

        // public Country ShippingCountryId { get; set; }
      */
        [Required(ErrorMessage = "Please enter street.")]
        public string Street { get; set; }
        
        [Required(ErrorMessage="Please enter ZipCode.")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Please enter city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please select country.")]
        public int CountryId { get; set; }
    }
}
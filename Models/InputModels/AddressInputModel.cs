using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class AddressInputModel
    {
        [Required(ErrorMessage="Please enter street.")]
        public string BillingStreet { get; set; }

        [Required(ErrorMessage="Please enter ZipCode.")]
        public string BillingZipcode { get; set; }
        [Required(ErrorMessage="Please enter city.")]   
        public string BillingCity { get; set; }
        [Required(ErrorMessage="Please select country.")]

        public Country BillingCountryId { get; set; }


        [Required(ErrorMessage="Please enter street.")]
  
        public string Street { get; set; }

        [Required(ErrorMessage="Please enter street.")]
        public string ShippingStreet { get; set; }

        [Required(ErrorMessage="Please enter ZipCode.")]
        public string ShippingZipcode { get; set; }
        [Required(ErrorMessage="Please enter city.")]   
        public string ShippingCity { get; set; }
        [Required(ErrorMessage="Please select country.")]

        public Country ShippingCountryId { get; set; }
               
    }
}
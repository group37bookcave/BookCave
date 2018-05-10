using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class CustomerInputModel
    {
        [Required(ErrorMessage="Please enter first name.")] 
        public string FirstName { get; set; }
        
        [Required(ErrorMessage="Please enter last name.")]
         public string LastName { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }
        
        
        public string FavoriteBook { get; set; }

        public byte[] Image { get; set; }

        public string PhoneNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }
        
        public string Zipcode { get; set; }

        public int CountryId { get; set; }
    }
}
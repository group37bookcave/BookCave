using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class CustomerInputModel
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }
        
        public string FavoriteBook { get; set; }

        public string PhoneNumber { get; set; }

        public string Street { get; set; }
        
        public string Zipcode { get; set; }

        public int CountryId { get; set; }
    }
}
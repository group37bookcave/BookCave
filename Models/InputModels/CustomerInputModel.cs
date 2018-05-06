using System.ComponentModel.DataAnnotations;

namespace BookCave.Services
{
    public class CustomerInputModel
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }

        public string Street { get; set; }
        
        public string Zipcode { get; set; }

        public string Country { get; set; }
    }
}
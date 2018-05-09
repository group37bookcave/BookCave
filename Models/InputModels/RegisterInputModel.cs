using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class RegisterInputModel
    {
        [Required(ErrorMessage = "Enter a valid email address"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter address.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter zipcode.")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Please enter city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please selet country.")]
        public int CountryId { get; set; }

        public byte[] Image { get; set; }

        public string FavoriteBook { get; set; }

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter a password"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Passwords do not match"), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
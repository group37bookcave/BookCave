using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class RegisterInputModel
    {
        [Required(ErrorMessage = "Enter a valid email address"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is manadatory")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is manadatory")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address missing")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Enter zipcode")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Enter your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Selet your country")]
        public int CountryId { get; set; }

        public Ima Type { get; set; }

        public string FavoriteBook { get; set; }

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter a password"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Passwords do not match"), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class LoginInputModel
    {

        [Required(ErrorMessage="Please enter a valid email address.")]

        [EmailAddress] public string Email { get; set; }

        [Required(ErrorMessage="Please enter password.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
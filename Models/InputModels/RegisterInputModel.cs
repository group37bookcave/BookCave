using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class RegisterInputModel
    {
        [Required(ErrorMessage = "Enter a valid email address")] [EmailAddress] public string Email { get; set; }

        [Required(ErrorMessage = "First name is manadatory")] public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is manadatory")] public string LastName { get; set; }

        [Required(ErrorMessage = "Enter a password")] public string Password { get; set; }
    }
}
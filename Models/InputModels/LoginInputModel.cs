using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class LoginInputModel
    {
        [EmailAddress] public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
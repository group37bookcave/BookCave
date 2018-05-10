using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BookCave.Models.InputModels
{
    public class EmployeeInputModel
    {
        [Required(ErrorMessage="Please enter email-address.")]
         [EmailAddress] public string Email { get; set; }

        [Required(ErrorMessage ="Please enter first name.")]
         public string FirstName { get; set; }

        [Required(ErrorMessage="Please enter last name.")] public string LastName { get; set; }
    }
}
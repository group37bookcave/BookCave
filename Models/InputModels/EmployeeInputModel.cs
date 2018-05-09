using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BookCave.Models.InputModels
{
    public class EmployeeInputModel
    {
        [Required] [EmailAddress] public string Email { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }
    }
}
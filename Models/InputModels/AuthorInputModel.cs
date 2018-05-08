using System.ComponentModel.DataAnnotations;

namespace BookCave.Models
{
    public class AuthorInputModel
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
    }
}
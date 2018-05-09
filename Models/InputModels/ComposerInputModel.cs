using System.ComponentModel.DataAnnotations;

namespace BookCave.Models
{
    public class ComposerInputModel
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
    }
}
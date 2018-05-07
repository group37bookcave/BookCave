using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class NarratorInputModel
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
    }
}
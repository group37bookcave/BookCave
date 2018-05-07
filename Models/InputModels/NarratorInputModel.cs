using System.ComponentModel.DataAnnotations;

namespace BookCave.Services
{
    public class NarratorInputModel
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        public int BookId { get; set; }
    }
}
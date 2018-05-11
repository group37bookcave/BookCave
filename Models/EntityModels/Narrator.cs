using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Narrator
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => LastName + ", " + FirstName;

        public ICollection<AudiobookNarrator> AudiobookNarrators { get; set; }
    }
}
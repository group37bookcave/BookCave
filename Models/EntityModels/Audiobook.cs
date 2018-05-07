using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Audiobook : Book
    {
        public double? Size { get; set; }

        public ICollection<AudiobookNarrator> AudiobookNarrators { get; set; }

    }
}
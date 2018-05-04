using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
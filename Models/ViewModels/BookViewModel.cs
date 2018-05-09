using System.Collections.Generic;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public double Price { get; set; }
        
        public string Name { get; set; }

        public string Image { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public string Description { get; set; }

        // In minutes if Audiobook, pages if not.
        public int Length { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public Publisher Publisher { get; set; }

        public Isbn Isbn { get; set; }
        
        public ICollection<BookLanguage> BookLanguages { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }

        public ICollection<BookAgeGroup> BookAgeGroups { get; set; }
    }
}
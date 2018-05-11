using System.Collections.Generic;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class AuthorViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => LastName + ", " + FirstName;

        public List<Book> Books { get; set; }
    }
}
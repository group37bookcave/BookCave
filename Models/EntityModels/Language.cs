using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Language
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookLanguage> BookLanguages { get; set; }
    }
}
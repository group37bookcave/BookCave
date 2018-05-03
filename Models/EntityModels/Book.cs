using System;
using System.Collections;
using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Book : Product
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public int Length { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        //Will be null when BookType is HardCover or Paperback
        public double? Size { get; set; }

        public BookType BookType { get; set; }

        public Publisher Publisher { get; set; }
        
        public ICollection<Language> Languages { get; set; }

        public ICollection<Author> Authors { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<AgeGroup> AgeGroups { get; set; }

        //Will be null when BookType is not AudioBook
        public ICollection<Narrator> Narrators { get; set; }
    }
}
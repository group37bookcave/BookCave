using System;
using System.Linq;
using System.Collections;
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

        public List<ReviewViewModel> Reviews { get; set; }

        public double Rating { get; set; }
        
        public string Description { get; set; }
        
        public string Format { get; set; }

        // In minutes if Audiobook, pages if not.
        public int Length { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public string Publisher { get; set; }

        public Isbn Isbn { get; set; }
        
        public List<Language> Languages { get; set; }

        public List<Author> Authors { get; set; }

        public List<Genre> Genres { get; set; }

        public List<AgeGroup> AgeGroups { get; set; }
    }
}
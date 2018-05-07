using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;

namespace BookCave.Models.InputModels
{
    public class PaperBackInputModel 
    {        
        [Required] public double Price { get; set; }
        
        [Required] public string Name { get; set; }
        
        [Required] public string Image { get; set; }
        
        [Required] public string Description { get; set; }

        [Required] public int? Pages { get; set; }

        [Required] public DateTime ReleaseDate { get; set; }

        [Required] public Publisher Publisher { get; set; }

        [Required] public List<Isbn> Isbns { get; set; }

        [Required] public List<Language> Languages { get; set; }

        [Required] public List<Author> Authors { get; set; }

        [Required] public List<Genre> Genres { get; set; }

        [Required] public List<AgeGroup> AgeGroups { get; set; }
    }
}
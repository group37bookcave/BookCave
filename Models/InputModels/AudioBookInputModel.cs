using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;


namespace BookCave.Models.InputModels
{
    public class AudioBookInputModel 
    {
        [Required] public double Price { get; set; }
        
        [Required] public string Name { get; set; }
        
        [Required] public string Image { get; set; }
        
        [Required] public string Description { get; set; }

        [Required] public int Length { get; set; }

        [Required] public double? Size { get; set; }

        [Required] public DateTime ReleaseDate { get; set; }

        [Required] public Publisher Publisher { get; set; }

        [Required] public Isbn Isbns { get; set; }

        [Required] public List<Language> Languages { get; set; }

        [Required] public List<Author> Authors { get; set; }

        [Required] public List<Genre> Genres { get; set; }

        [Required] public List<AgeGroup> AgeGroups { get; set; }
        
        [Required] public List<Narrator> Narrators { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;

namespace BookCave.Models.InputModels
{


    public class HardCoverInputModel
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

    public class AudioBookInputModel 
    {
        [Required] public double Price { get; set; }
        
        [Required] public string Name { get; set; }
        
        [Required] public string Image { get; set; }
        
        [Required] public string Description { get; set; }

        [Required] public int? Length { get; set; }
        
        [Required] public double? Size { get; set; }

        [Required] public DateTime ReleaseDate { get; set; }

        [Required] public Publisher Publisher { get; set; }
        
        [Required] public List<Isbn> Isbns { get; set; }

        [Required] public List<Language> Languages { get; set; }

        [Required] public List<Author> Authors { get; set; }

        [Required] public List<Genre> Genres { get; set; }

        [Required] public List<AgeGroup> AgeGroups { get; set; }
        
        [Required] public List<NarratorInputModel> Narrators { get; set; }
    }

    public class NarratorInputModel
    {
        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }
    }

    public class EbookInputModel 
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
        
        [Required] public double? Size { get; set; }
    }
}
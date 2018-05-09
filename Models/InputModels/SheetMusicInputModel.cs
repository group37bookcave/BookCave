using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;

namespace BookCave.Models.InputModels
{
    public class SheetMusicInputModel 
    {        
        [Required] public double Price { get; set; }
        
        [Required] public string Name { get; set; }
        
        [Required] public string Image { get; set; }
        
        [Required] public string Description { get; set; }

        [Required] public int Pages { get; set; }

        public double? Size { get; set; } 

        [Required] public DateTime ReleaseDate { get; set; }

        [Required] public Publisher Publisher { get; set; }

        [Required] public Isbn Isbns { get; set; }

        [Required] public List<Composer> Composers { get; set; }

    }
}
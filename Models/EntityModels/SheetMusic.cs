using System;
using System.Collections;
using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public abstract class SheetMusic : Product
    {
        public string Description { get; set; }

        // In minutes if Audiobook, pages if not.
        public int Length { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public Publisher Publisher { get; set; }

        public Isbn Isbn { get; set; }
        public ICollection<SheetMusicComposer> SheetMusicComposers { get; set; }
    }
}
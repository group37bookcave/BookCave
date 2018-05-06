using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public abstract class SheetMusic : Product
    {
        public ICollection<SheetMusicComposer> SheetMusicComposers { get; set; }
    }
}
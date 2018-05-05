using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Composer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => FirstName + ", " + LastName;

        public ICollection<SheetMusicComposer> SheetMusicComposers { get; set; }
    }
}
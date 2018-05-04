using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Format
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SheetMusic> SheetMusics { get; set; }
    }
}
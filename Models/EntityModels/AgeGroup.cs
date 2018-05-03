using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class AgeGroup
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class AgeGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookAgeGroup> BookAgeGroups { get; set; }
    }
}
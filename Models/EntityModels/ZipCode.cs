using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class ZipCode
    {
        public int Id { get; set; }

        public string Zip { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}
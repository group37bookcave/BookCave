using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Country
    {
        public int Id { get; set; }

        public string CountryCode { get; set; }

        public string Name { get; set; }

        public ICollection<ZipCode> ZipCodes { get; set; }
    }
}
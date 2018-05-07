using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public ICollection<Address> Addresses { get; set; }

        public ICollection<CountryZipCode> CountryZipCodes { get; set; }
    }
}
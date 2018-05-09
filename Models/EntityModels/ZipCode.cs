using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class ZipCode
    {
        public int Id { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public Country Country { get; set; }
    }
}
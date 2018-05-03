using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Address
    {
        public int Id { get; set; }

        public ZipCode ZipCode { get; set; }

        public Country Country { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
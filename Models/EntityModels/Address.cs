using System;
using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public ZipCode ZipCode { get; set; }

        public string City { get; set; }

        public Country Country { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
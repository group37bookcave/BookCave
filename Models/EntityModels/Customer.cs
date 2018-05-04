using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Customer : User
    { 
        public string PhoneNumber { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
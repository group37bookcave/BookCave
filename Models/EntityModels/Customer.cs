using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Customer : User
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Order> Orders { get; set; }
        
        
    }
}
using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Customer
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Email { get; set; }

        public string FullName => LastName + ", " + FirstName;

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}    
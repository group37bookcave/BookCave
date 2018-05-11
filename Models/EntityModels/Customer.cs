using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Customer
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string FavoriteBook { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName => FirstName + " " + LastName;

        public WishList WishList { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public ICollection<Order> Orders { get; set; }
        
        public ICollection<Review> Reviews { get; set; }
    }
}    
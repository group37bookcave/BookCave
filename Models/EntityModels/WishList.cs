using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class WishList
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public ICollection<WishListProduct> Products { get; set; }
    }
}
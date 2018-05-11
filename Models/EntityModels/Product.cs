
using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public abstract class Product
    {
        public int Id { get; set; }

        public double Price { get; set; }
        
        public string Name { get; set; }

        public string Image { get; set; }

        public ICollection<WishListProduct> WishLists { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
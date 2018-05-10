
using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public abstract class Product
    {
        public int Id { get; set; }

        public double Price { get; set; }
        
        public string Name { get; set; }

        public string Image { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
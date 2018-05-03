using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class ProductType
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
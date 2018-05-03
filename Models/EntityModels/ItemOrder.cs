using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class ItemOrder
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Order Order { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
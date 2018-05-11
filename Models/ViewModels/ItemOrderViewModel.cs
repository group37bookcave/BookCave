using System.Collections.Generic;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class ItemOrderViewModel
    {
        public int ProductId { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
        
        public int Quantity { get; set; }
    }
}
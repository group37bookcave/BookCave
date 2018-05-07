using System.Collections.Generic;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class ItemOrderViewModel
    {
        public Product Item { get; set; }
        public int Quantity { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class OrderViewModel 
    {
        public int OrderId { get; set; }
        
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public List<ItemOrderViewModel> Items { get; set; }
    }
}
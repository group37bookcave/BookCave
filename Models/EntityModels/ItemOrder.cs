﻿using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class ItemOrder
    {
        public int Id { get; set; }
        
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }

    }
}
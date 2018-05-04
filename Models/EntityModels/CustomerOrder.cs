﻿namespace BookCave.Models.EntityModels
{
    public class CustomerOrder
    {
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
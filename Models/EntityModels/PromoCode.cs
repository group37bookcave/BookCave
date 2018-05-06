using System;
using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class PromoCode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Rate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
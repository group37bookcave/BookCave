using System.Collections.Generic;

namespace BookCave.Models.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        
        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public Address Address { get; set; }

        public PromoCode PromoCode { get; set; }

        public ICollection<ItemOrder> ItemOrders { get; set; }

        public bool IsCheckedOut { get; set; }
    }
}
using System;

namespace BookCave.Models.EntityModels
{
    public class Review
    {
        public int Id { get; set; }

        public string ReviewString { get; set; }

        public int? Rating { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public DateTime DateReviewed { get; set; }
    }
}
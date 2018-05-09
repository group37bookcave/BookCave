using System;

namespace BookCave.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public DateTime DateReviewed { get; set; }
        public CustomerViewModel ReviewedBy { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
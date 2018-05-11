using System;

namespace BookCave.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public int? Rating { get; set; }
        public string ReviewedBy { get; set; }
        public int CustomerId { get; set; }
    }
}
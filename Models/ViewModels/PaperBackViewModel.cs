using System.Collections.Generic;
namespace BookCave.Models.ViewModels
{
    public class PaperBackViewModel
    {
        public int ProductId { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
    }
}
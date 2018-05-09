using System.Collections.Generic;
namespace BookCave.Models.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; } 
        public string Title { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }
}
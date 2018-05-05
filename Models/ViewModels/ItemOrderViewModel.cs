using System.Collections.Generic;
namespace BookCave.Models.ViewModels
{
    public class ItemOrderViewModel
    {
        public List<ProductViewModel> Item { get; set; }
        public int Quantity { get; set; }
    }
}
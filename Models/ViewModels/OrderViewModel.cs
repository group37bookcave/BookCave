using System.Collections.Generic;
namespace BookCave.Models.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public List<ItemOrderViewModel> Items { get; set; }
    }
}
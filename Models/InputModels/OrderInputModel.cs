using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Models.InputModels
{
    public class OrderInputModel
    {
        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        [Required]
        public Address Address { get; set; }
        
        [Required]
        public List<ItemOrderViewModel> Items { get; set; }

        public PromoCode PromoCode { get; set; }

        public bool IsCheckedOut { get; set; }
    }
}
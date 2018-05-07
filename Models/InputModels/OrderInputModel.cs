using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookCave.Models.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class OrderInputModel
    {
        public CustomerViewModel Customer { get; set; }

        [Required]
        public Address Address { get; set; }
        
        [Required]
        public List<ItemOrderViewModel> Items { get; set; }

        public PromoCode PromoCode { get; set; }
    }
}
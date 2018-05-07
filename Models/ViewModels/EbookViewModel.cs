using System.Collections.Generic;
using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class EbookViewModel
    {
        public int ProductId { get; set; } 
        public string Title { get; set; }
        public double Price { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
        public string Image { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public double Size { get; set; }
        public string Format { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class ReviewInputModel
    {
        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public string Review { get; set; }

        [Required] public int? Rating { get; set; }
    }
}
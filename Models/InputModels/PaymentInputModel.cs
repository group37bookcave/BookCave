using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class PaymentInputModel
    {
        [Required(ErrorMessage="Please input card holders name.")]
        public string CardName { get; set; }

        [Required(ErrorMessage="Please input card number.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage="Please select expiration month.")]
     
        public int? ExpirationMonth { get; set; }
        
        [Required(ErrorMessage="Please select expiration year.")]
        
        public int? ExpirationYear { get; set; }
        
        [Required(ErrorMessage="Please input CVV.")]
    
        public int? CVV { get; set; }
    }
}
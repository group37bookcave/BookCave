using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class CustomerViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<AddressViewModel> Adresses { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
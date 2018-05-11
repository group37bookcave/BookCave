using BookCave.Models.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class AddressViewModel
    {
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public Country Country { get; set; }
        public int AddressId { get; set; }
    }
}
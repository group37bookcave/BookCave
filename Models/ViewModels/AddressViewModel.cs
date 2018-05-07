namespace BookCave.Models.ViewModels
{
    public class AddressViewModel
    {
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CountryId { get; set; }
        public int AddressId { get; set; }
    }
}
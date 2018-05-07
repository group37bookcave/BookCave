namespace BookCave.Repositories
{
    public class AddressInputModel
    {
        public string Street { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public int CountryId { get; set; }
    }
}
namespace BookCave.Models.EntityModels
{
    public class CountryZipCode
    {
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int ZipCodeId { get; set; }

        public ZipCode ZipCode { get; set; }
    }
}
namespace BookCave.Models.EntityModels
{
    public class CustomerAddress
    {
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}
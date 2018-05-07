using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class AddressRepo
    {
        private StoreContext _db = new StoreContext();

        public List<Address> GetAddresses(Customer customer)
        {
            var addresses = from a in _db.Addresses
                join c in _db.CustomerAddresses on a.Id equals c.AddressId
                where c.CustomerId == customer.Id
                select a;
            return addresses.ToList();
        }
       
    }
}
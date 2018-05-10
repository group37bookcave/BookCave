using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class AddressRepo
    {
        private readonly StoreContext _db = new StoreContext();
        private readonly CountryRepo _countryRepo = new CountryRepo();
        private readonly CustomerRepo _customerRepo = new CustomerRepo();

        public List<Address> GetAddressesByCustomerId(int id)
        {
            var adresses = (from ca in _db.CustomerAddresses
                join a in _db.Addresses on ca.AddressId equals a.Id
                where ca.CustomerId == id
                select a).ToList();
            return adresses;
        }

        public void DeleteAddressByAddressId(int id)
        {
            var address = new Address {Id = id};
            _db.Addresses.Remove(address);
            _db.SaveChanges();
        }

        public void AddAddressToCustomer(int customerId, int addressId)
        {
            _db.CustomerAddresses.Add(new CustomerAddress {AddressId = addressId, CustomerId = customerId});
            _db.SaveChanges();
        }

        public void AddAddress(Address address)
        {
            _db.Addresses.Add(address);
            _db.SaveChanges();
        }
    }
}
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

        public void AddAddressToCustomer(int customerId, Address model)
        {
            var customer = _customerRepo.GetCustomer(customerId);
            customer.CustomerAddresses.Add(new CustomerAddress {Address = model, Customer = customer});
            _db.Update(customer);
            _db.SaveChanges();
        }

        public Address NewAddress(string street, string zipcode, string city, int countryId)
        {
            var country = _db.Countries.Find(countryId);
            var address = new Address
            {
                Street = street,
                ZipCode = zipcode,
                City = city,
                CountryId = country.Id
            };
            _db.Addresses.Add(address);
            _db.SaveChanges();
            return address;
        }
    }
}
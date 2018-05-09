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
        
        private ZipCode GetZipCode(string zip, int countryId)
        {
            var zipcode = from z in _db.ZipCodes
                join c in _db.Countries on z.Country.Id equals c.Id
                where c.Id == countryId
                select z;
                
            return zipcode.SingleOrDefault();
        }

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
            customer.CustomerAddresses.Add(new CustomerAddress { Address = model, Customer = customer});
            _db.Update(customer);
            _db.SaveChanges();
        }

        public Address NewAddress(string street, string zipcode, string city, int countryId)
        {
            var zip = GetZipCode(zipcode, countryId) ?? CreateZipCode(zipcode, city, countryId);

            var address = new Address
            {
                Street = street,
                ZipCode = zip
            };
            return address;
        }

        private ZipCode CreateZipCode(string zipcode, string city, int countryId)
        {
            var zip = new ZipCode
            {
                City = city,
                Zip = zipcode,
                Country = _countryRepo.GetCountryById(countryId)
            };
            _db.ZipCodes.AddRange(zip);
            _db.SaveChanges();
            return zip;
        }
    }
}
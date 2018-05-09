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
            var zipcode = from c in _db.CountryZipCodes
                join z in _db.ZipCodes on c.ZipCode.Zip equals zip
                where c.CountryId == countryId
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

        public void AddAddressToCustomer(int customerId, AddressInputModel model)
        {
            var customer = _customerRepo.GetCustomer(customerId);
            var address = NewAddress(model.Street,model.Zipcode, model.City, model.CountryId);
            customer.CustomerAddresses.Add(new CustomerAddress { Address = address, Customer = customer});
            _db.AddRange(address);
            _db.SaveChanges();
        }

        public Address NewAddress(string street, string zipcode, string city, int countryId)
        {
            var zip = GetZipCode(zipcode, countryId) ?? new ZipCode
            {
                City = city,
                Zip = zipcode,
                Country = _countryRepo.GetCountryById(countryId)
            };
            
            var address = new Address
            {
                Street = street,
                ZipCode = zip
            };
            
            _db.Addresses.AddRange(address);
            _db.SaveChanges();
            return address;
        }
    }
}
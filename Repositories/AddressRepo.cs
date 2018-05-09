using System.Collections.Generic;
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
        
        private ZipCode GetZipCode(string zip, Country country)
        {
            var zipcode = from c in _db.CountryZipCodes
                join z in _db.ZipCodes on c.ZipCode.Zip equals zip
                where c.CountryId == country.Id
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
            var country = _countryRepo.GetCountryById(model.CountryId);
            var zip = GetZipCode(model.Zipcode, country) ?? new ZipCode
            {
                City = model.City,
                Zip = model.Zipcode
            };
            var address = new Address
            {
                Street = model.Street,
                ZipCode = zip,
                Country = country,
            };
            var customer = _customerRepo.GetCustomer(customerId);
            address.CustomerAddresses.Add(new CustomerAddress { Address = address, Customer = customer});
            _db.AddRange(address);
            _db.SaveChanges();

        }
    }
}
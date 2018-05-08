using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Services;

namespace BookCave.Repositories
{
    public class CustomerRepo
    {
        
        private readonly StoreContext _db = new StoreContext();

        public int AddCustomer(CustomerInputModel user)
        {
            var customer = new Customer
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            _db.Customers.AddRange(customer);
            _db.SaveChanges();
            return customer.Id;
        }

        public Customer GetCustomer(int id)
        {
            var customer = from c in _db.Customers where c.Id == id select c;
            return customer.SingleOrDefault();
        }
        
        public void AddAddressToCustomer(int customerId, AddressInputModel model)
        {
            var customer = GetCustomer(customerId);
            var country = (from c in _db.Countries where c.Id == model.CountryId select c).FirstOrDefault();
            var address = new Address
            {
                Country = country,
                Street = model.Street,
                ZipCode = new ZipCode
                {
                    City = model.City,
                    Zip = model.Zipcode
                }
            };
            address.CustomerAddresses.Add(new CustomerAddress
            {
                Address = address,
                Customer = customer
            });
            _db.Add(address);
            _db.SaveChanges();
        }
        
        public List<Address> GetAddresses(int customerId)
        {
            var addresses = from a in _db.Addresses
                join c in _db.CustomerAddresses on a.Id equals c.AddressId
                where c.CustomerId == customerId
                select a;
            return addresses.ToList();
        }
    }
}
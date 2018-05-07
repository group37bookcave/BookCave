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
        private StoreContext _db = new StoreContext();

        public void AddCustomer(CustomerInputModel user)
        {
            var customer = new Customer
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }

        public Customer GetCustomer(string email)
        {
            var customer = from c in _db.Customers where c.Email.Equals(email) select c;
            return customer.FirstOrDefault();
        }
        
        
    }
}
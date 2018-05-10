using System;
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

        public int AddCustomer(Customer user)
        {
            _db.Customers.AddRange(user);
            _db.SaveChanges();
            return user.Id;
        }

        public Customer GetCustomer(int id)
        {
            var customer = from c in _db.Customers where c.Id == id select c;
            return customer.SingleOrDefault();
        }
    }
}
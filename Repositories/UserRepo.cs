using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class UserRepo
    {
        private readonly StoreContext _db = new StoreContext();

        public Employee GetEmployee(int id)
        {
            return (from e in _db.Employees where e.Id == id select e).FirstOrDefault();
        }

        public Customer GetCustomer(int id)
        {
            return (from c in _db.Customers where c.Id == id select c).FirstOrDefault();
        }
       
    }
}
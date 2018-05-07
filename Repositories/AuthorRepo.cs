using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class AuthorRepo
    {
        private StoreContext _db = new StoreContext();

        public void AddAuthor()

        public List<Author> GetAllAuthors()
        {
            return (from a in _db.Authors
                select a).ToList();
        }

        public Author GetAuthor(int id)
        {
            return (from a in _db.Authors where a.Id == id select a).FirstOrDefault();
        }
    }
}
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
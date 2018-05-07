using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Services;

namespace BookCave.Repositories
{
    public class AuthorRepo
    {
        private StoreContext _db = new StoreContext();

        public void AddAuthor(AuthorInputModel user)
        {
            var author = new Author
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            _db.Authors.Add(author);
            _db.SaveChanges();
        }

        public List<Author> GetAllAuthors()
        {
            return (from a in _db.Authors
                select a).ToList();
        }

        public Author GetAuthor(int id)
        {
            return (from a in _db.Authors 
                where a.Id == id 
                select a).FirstOrDefault();
        }
    }
}
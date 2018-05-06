using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class AuthorRepo
    {
        private StoreContext _db;

        public AuthorRepo()
        {
            _db = new StoreContext();
        }

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
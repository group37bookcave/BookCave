using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class GenreRepo
    
    {
        private StoreContext _db = new StoreContext();

        public Genre GetGenre(int id)
        {
            return (from g in _db.Genres where g.Id == id select g).FirstOrDefault();
        }

        public List<Genre> GetAllGenres()
        {
            return (from g in _db.Genres select g).ToList();
        }
        
    }
}
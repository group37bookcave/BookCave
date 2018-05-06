using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class NarratorRepo
    {
        private StoreContext _db = new StoreContext();

        public List<Narrator> GetAllNarrators()
        {
            return (from n in _db.Narrators
                select n).ToList();
        }

        public Narrator GetNarrator(int id)
        {
            return (from n in _db.Narrators where n.Id == id select n).FirstOrDefault();
        }
    }
}
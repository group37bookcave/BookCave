using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;

namespace BookCave.Repositories
{
    public class NarratorRepo
    {
        private StoreContext _db = new StoreContext();

        public void AddNarrator(NarratorInputModel user)
        {
            var narrator = new Narrator
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            _db.Narrators.Add(narrator);
            _db.SaveChanges();
        }

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
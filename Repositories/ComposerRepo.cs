using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Services;

namespace BookCave.Repositories
{
    public class ComposerRepo
    {
        private StoreContext _db = new StoreContext();

        public void AddComposer(ComposerInputModel user)
        {
            var composer = new Composer
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            _db.Composers.Add(composer);
            _db.SaveChanges();
        }

        public List<Composer> GetAllComposers()
        {
            return (from c in _db.Composers
                select c).ToList();
        }

        public Composer GetComposer(int id)
        {
            return (from c in _db.Composers
                where c.Id == id 
                select c).FirstOrDefault();
        }
    }
}
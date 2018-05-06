using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class PublisherRepo
    {
        private StoreContext _db = new StoreContext();

        public Publisher GetPublisher(int id)
        {
            return (from p in _db.Publishers where p.Id == id select p).FirstOrDefault();
        }

        public List<Publisher> GetAllPublishers()
        {
            return (from p in _db.Publishers select p).ToList();
        }
    }
}
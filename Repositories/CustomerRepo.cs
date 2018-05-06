using System.Collections.Generic;
using BookCave.Data;
using BookCave.Models.InputModels;

namespace BookCave.Repositories
{
    public class CustomerRepo
    {
        private StoreContext _db = new StoreContext();

        public CustomerRepo(StoreContext db)
        {
            _db = db;
        }
    }
}
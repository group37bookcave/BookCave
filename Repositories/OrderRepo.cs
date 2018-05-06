using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        private StoreContext _db = new StoreContext();


        public void AddOrder(int customerId, OrderInputModel order)
        {
            
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.InputModels;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        private StoreContext _db = new StoreContext();
        public List<Order> GetOrdersByCustomerId(int id)
        {
            var orders = (from o in _db.Orders
                where o.Customer.Id == id
                select o).ToList();


                return orders;
        }

        public List<Order> GetAllOrderss()
        {
            return (from o in _db.Orders
                select o).ToList();
        }
        public void AddOrder(int customerId, OrderInputModel order)
        {
            
        }
    }
}
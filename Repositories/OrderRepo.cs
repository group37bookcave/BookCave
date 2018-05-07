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
            var orders = (from co in _db.CustomerOrders
                join o in _db.Orders on co.OrderId equals o.Id
                where co.CustomerId == id
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
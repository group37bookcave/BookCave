using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        private StoreContext _db = new StoreContext();
        private ProductRepo _pr = new ProductRepo();
        private CustomerRepo _cr = new CustomerRepo();

        public List<Order> GetAllOrdersByCustomerId(int customerId)
        {
            var orders = from o in _db.Orders where o.Customer.Id == customerId select o;
            return orders.ToList();
        }

        public List<PromoCode> GetAllValidPromoCodes()
        {
            var current = DateTime.Today;
            var codes = from pc in _db.PromoCodes where current <= pc.EndDate && current >= pc.StartDate select pc;
            return codes.ToList();
        }

        public Order GetOrderById(int orderId)
        {
            var order = from o in _db.Orders where o.Id == orderId select o;
            return order.SingleOrDefault();
        }
        
        public void AddOrder(OrderInputModel model)
        {
            var products = new List<ItemOrder>();
            foreach (var item in model.Items)
            {
                products.Add(
                    new ItemOrder {Product = item.Item, Quantity = item.Quantity});
            }
            var order = new Order
            {
                Address = model.Address,
                Customer = _cr.GetCustomer(model.Customer.Id),
                ItemOrders = products,
                PromoCode = model.PromoCode
            };
            _db.Orders.AddRange(order);
            _db.SaveChanges();
        }
    }
}
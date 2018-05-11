using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        private readonly StoreContext _db = new StoreContext();
        private readonly CustomerRepo _cr = new CustomerRepo();
        private readonly ProductRepo _pr = new ProductRepo();


        public IEnumerable<ItemOrderViewModel> GetItemOrderViewModels(int itemorderId)
        {
            var items = from item in _db.ItemOrders
                join product in _db.Products on item.ProductId equals product.Id
                where item.Id == itemorderId
                select new ItemOrderViewModel
                {
                    Image = product.Image,
                    Name = product.Name,
                    Price = product.Price,
                    ProductId = product.Id,
                    Quantity = item.Quantity
                };
            return items;
        }

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

        private Order GetOrderById(int orderId)
        {
            var order = from o in _db.Orders where o.Id == orderId select o;
            return order.SingleOrDefault();
        }

        public Order UpdateOrder(OrderInputModel model)
        {
            var order = GetOrderById(model.OrderId);

            order.Address = model.Address;
            order.ItemOrders = ConvertToItemOrder(model.Items);
            order.PromoCode = model.PromoCode;
            _db.SaveChanges();
            return order;
        }

        public void RemoveFromOrder(int productId, int orderId)
        {
            var order = GetOrderById(orderId);
            RemoveItem(productId, order);
        }

        private void RemoveItem(int productId, Order order)
        {
            var item = (from i in order.ItemOrders where i.ProductId == productId select i).SingleOrDefault();
            order.ItemOrders.Remove(item);
            _db.Update(order);
            _db.SaveChanges();
        }

        public void AddToOrder(int productId, int orderId)
        {
            var order = GetOrderById(orderId);
            var itemorder = GetItemOrder(productId, order.ItemOrders);
            if (itemorder != null)
            {
                itemorder.Quantity++;
                _db.Update(itemorder);
            }
            else
            {
                itemorder = new ItemOrder
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = 1
                };
                order.ItemOrders.Add(itemorder);
                _db.Update(order);
            }

            _db.SaveChanges();
        }

        private ItemOrder GetItemOrder(int productId, IEnumerable<ItemOrder> items)
        {
            return items.FirstOrDefault(item => item.ProductId == productId);
        }

        private List<ItemOrder> ConvertToItemOrder(IEnumerable<ItemOrderViewModel> items)
        {
            return items.Select(item =>
                new ItemOrder
                {
                    Product = _pr.GetProduct(item.ProductId),
                    Quantity = item.Quantity
                }).ToList();
        }

        public bool CheckoutOrder(int orderId)
        {
            var order = (from o in _db.Orders where o.Id == orderId select o).SingleOrDefault();
            if (order == null)
            {
                return false;
            }

            order.IsCheckedOut = true;
            _db.SaveChanges();
            return true;
        }

        public Order GetActiveOrder(int customerId)
        {
            if (!HasActiveOrder(customerId))
            {
                return CreateNewOrder(customerId);
            }

            var order = from o in _db.Orders where o.Customer.Id == customerId && o.IsCheckedOut select o;
            return order.SingleOrDefault();
        }

        private Order CreateNewOrder(int customerId)
        {
            var order = new Order
            {
                Customer = _cr.GetCustomer(customerId),
                IsCheckedOut = false,
            };
            _db.Orders.Add(order);
            _db.SaveChanges();
            return order;
        }

        private bool HasActiveOrder(int customerId)
        {
            var order = from o in _db.Orders
                where o.Customer.Id == customerId && o.IsCheckedOut == false
                select o;
            return order.Any();
        }
    }
}
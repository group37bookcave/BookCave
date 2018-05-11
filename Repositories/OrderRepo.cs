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
        private readonly ProductRepo _pr = new ProductRepo();

        public List<OrderViewModel> GetAllOrdersByCustomerId(int customerId)
        {
            var orders = (from order in _db.Orders where order.CustomerId == customerId select new OrderViewModel
            {
                CustomerId = customerId,
                OrderId = order.Id,
                OrderDate = order.Date,
                Status = order.Status,
            }).ToList();
            foreach (var item in orders)
            {
                item.Items = GetItemOrdersByOrderId(item.OrderId);

            }
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
        
        private List<ItemOrder> ConvertToItemOrder(IEnumerable<ItemOrderViewModel> items)
        {
            return items.Select(item =>
                new ItemOrder
                {
                    Product = _pr.GetProduct(item.ProductId),
                    Quantity = item.Quantity
                }).ToList();
        }

        public void RemoveFromOrder(int productId, int orderId)
        {
            var orderItem = (from i in _db.ItemOrders where i.OrderId == orderId && i.ProductId == productId select i)
                .SingleOrDefault();
            if (orderItem == null)
            {
                return;
            }

            _db.Remove(orderItem);
            _db.SaveChanges();
        }

        public void AddToOrder(int productId, int orderId)
        {
            var itemorder = GetItemOrder(productId, orderId);
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
                _db.ItemOrders.Add(itemorder);
            }

            _db.SaveChanges();
        }

        private ItemOrder GetItemOrder(int productId, int orderId)
        {
            var item = (from i in _db.ItemOrders where i.OrderId == orderId && i.ProductId == productId select i)
                .SingleOrDefault();
            return item;
        }

        private List<ItemOrderViewModel> GetItemOrdersByOrderId(int orderId)
        {
            var items = from i in _db.ItemOrders
                join p in _db.Products on i.ProductId equals p.Id
                where i.OrderId == orderId
                select new ItemOrderViewModel
                {
                    ProductId = p.Id,
                    Quantity = i.Quantity,
                    ProductName = p.Name,
                    Image = p.Image,
                    Price = p.Price
                };
            return items.ToList();
        }

        public bool CheckoutOrder(int orderId)
        {
            var order = (from o in _db.Orders where o.Id == orderId select o).SingleOrDefault();
            if (order == null)
            {
                return false;
            }

            order.IsCheckedOut = true;
            order.Date = DateTime.Today;
            _db.Update(order);
            _db.SaveChanges();
            return true;
        }

        public OrderViewModel GetActiveOrder(int customerId)
        {
            if (!HasActiveOrder(customerId))
            {
                return CreateNewOrder(customerId);
            }

            var order = (from o in _db.Orders
                where o.Customer.Id == customerId && !o.IsCheckedOut
                select new OrderViewModel
                {
                    CustomerId = o.CustomerId,
                    OrderId = o.Id,
                    Items = GetItemOrdersByOrderId(o.Id)
                }).SingleOrDefault();
            return order;
        }

        private OrderViewModel CreateNewOrder(int customerId)
        {
            var order = new Order
            {
                CustomerId = customerId,
                IsCheckedOut = false,
                ItemOrders = new List<ItemOrder>(),
            };
            _db.Orders.Add(order);
            _db.SaveChanges();
            return new OrderViewModel
            {
                CustomerId = order.CustomerId,
                OrderId = order.Id,
                Items = new List<ItemOrderViewModel>()
            };
        }

        private bool HasActiveOrder(int customerId)
        {
            var order = from o in _db.Orders
                where o.Customer.Id == customerId && !o.IsCheckedOut
                select o;
            return order.Any();
        }
    }
}
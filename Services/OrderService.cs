using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;


namespace BookCave.Services
{
    public class OrderService
    {
        private readonly OrderRepo _orderRepo = new OrderRepo();

        public OrderViewModel UpdateOrder(OrderInputModel model)
        {
            var order = _orderRepo.UpdateOrder(model);
            var viewModel = new OrderViewModel
            {
                OrderId = order.Id,
                CustomerId = order.Customer.Id,
                Items = ConvertToItemOrderViewModels(order.ItemOrders)
            };
            return viewModel;
        }
        
        private static List<ItemOrderViewModel> ConvertToItemOrderViewModels(IEnumerable<ItemOrder> model)
        {
            var itemOrder = model?.Select(item => new ItemOrderViewModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                })
                .ToList();
            return itemOrder;
        }

        public bool CheckoutOrder(OrderInputModel model)
        {
            return _orderRepo.CheckoutOrder(model.OrderId);
        }

        public void AddToOrder(int productId, OrderViewModel order)
        {
            _orderRepo.AddToOrder(productId, order.OrderId);
        }

        public OrderViewModel GetActiveOrder(int customerId)
        {
            return _orderRepo.GetActiveOrder(customerId);
        }

        public List<OrderViewModel> OrderHistory(int customerId)
        {
            return _orderRepo.GetAllOrdersByCustomerId(customerId);
            
        }
        
        public void RemoveItem(int id, OrderViewModel order)
        {
            _orderRepo.RemoveFromOrder(id, order.OrderId);
        }
    }
}
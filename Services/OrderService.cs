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
                Items = ConvertToViewModel(order.ItemOrders)
            };
            return viewModel;
        }

        public bool CheckoutOrder(OrderInputModel model)
        {
            return _orderRepo.CheckoutOrder(model.OrderId);
        }

        public OrderViewModel AddToOrder(int productId, int orderId)
        {
            var order = _orderRepo.AddToOrder(productId, orderId);
            return ConvertToOrderViewModel(order);
        }


        private static OrderViewModel ConvertToOrderViewModel(Order order)
        {
            var viewModel = new OrderViewModel
            {
                CustomerId = order.Customer.Id,
                Items = ConvertToViewModel(order.ItemOrders),
                OrderId = order.Id
            };
            return viewModel;
        }

        private static List<ItemOrderViewModel> ConvertToViewModel(IEnumerable<ItemOrder> model)
        {
            return model.Select(itemOrder =>
                new ItemOrderViewModel
                {
                    ProductId = itemOrder.Product.Id,
                    Quantity = itemOrder.Quantity
                }).ToList();
        }
    }
}
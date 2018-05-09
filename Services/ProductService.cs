using System;
using System.Collections.Generic;
using BookCave.Models.EntityModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class ProductService
    {
        private readonly ProductRepo _productRepo = new ProductRepo();

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            var product = _productRepo.GetProduct(id);
            return product;
        }


        public Product RemoveProduct(int id)
        {
            var productToRemove = _productRepo.GetProduct(id);
          /*  productToRemove.Remove(productToRemove);*/
            return productToRemove;
        }

        private ProductViewModel ConvertToProductViewModel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _productRepo.GetAllBooks();
        }
    }
}
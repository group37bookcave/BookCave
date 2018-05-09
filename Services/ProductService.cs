using System;
using System.Collections.Generic;
using BookCave.Models.EntityModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class ProductService
    {
        private ProductRepo _productRepo = new ProductRepo();

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }


    }
}
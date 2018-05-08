using System;
using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class ProductService
    {
        private ProductRepo _pr = new ProductRepo();

        public List<ProductViewModel> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        private ProductViewModel ConvertToProductViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
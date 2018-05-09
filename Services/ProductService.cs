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

        private ProductViewModel ConvertToProductViewModel()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _productRepo.GetAllBooks();
        }
        public List<Book> GetBooksByAuthorId(int id)
        {
            return _productRepo.GetBooksByAuthorId(id);
        }
        public List<Author> GetAuthorsByBookId(int id)
        {
            return _productRepo.GetAuthorsByBookId(id);
        }
        public List<Book> SearchByName(string name)
        {
            return _productRepo.GetBooksByName(name);
        }
        public List<Book> SearchByAuthor(string name)
        {
            return _productRepo.GetBooksByAuthorName(name);
        }
        public Book SearchByIsbn(Isbn isbn)
        {
            return _productRepo.GetBookByIsbn(isbn);
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using BookCave.Models.EntityModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;


namespace BookCave.Services
{
    public class ProductService
    {
        private readonly ProductRepo _productRepo = new ProductRepo();

        public List<BookViewModel> Top10()
        {
            var books = _productRepo.GetTop10();
            return ConvertToBookViewModel(books);
        }
        
        private List<BookViewModel> ConvertToBookViewModel(IEnumerable<Book> books)
        {
            var viewModels = new List<BookViewModel>();
            foreach(var book in books)
            {
                var model = GetBookById(book.Id);
                viewModels.Add(model);
            }
            return viewModels;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }

        public BookViewModel GetBookById(int? id)
        {
            var book = (Book) GetProduct(id);
            return new BookViewModel
            {
                Id = book.Id,
                Price = book.Price,
                Name = book.Name,
                Image = book.Image,
                Reviews = _productRepo.GetBookReview(book.Id),
                Description = book.Description,
                Format = book.GetType().Name,
                Length = book.Length,
                ReleaseDate = book.ReleaseDate,
                Publisher = _productRepo.GetPublisherByBookId(book.Id),
                Isbn = book.Isbn,
                Authors = _productRepo.GetAuthorsByBookId(book.Id),
                Languages = _productRepo.GetBookLanguages(book.Id),
                Genres = _productRepo.GetBookGenres(book.Id),
                AgeGroups = _productRepo.GetBookAgeGroup(book.Id)
            };
        }

        public Product GetProduct(int? id)
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

        public List<BookViewModel> GetAllBooks()
        {
            return ConvertToBookViewModel(_productRepo.GetAllBooks());
        }
        public List<Book> GetBooksByAuthorId(int id)
        {
            return _productRepo.GetBooksByAuthorId(id);
        }
        public List<Author> GetAuthorsByBookId(int id)
        {
            return _productRepo.GetAuthorsByBookId(id);
        }
        public List<BookViewModel> SearchByName(string name)
        {
            return ConvertToBookViewModel(_productRepo.GetBooksByName(name));
        }
        public List<BookViewModel> SearchByAuthor(string name)
        {
            return ConvertToBookViewModel(_productRepo.GetBooksByAuthorName(name));
        }
        public List<BookViewModel> SearchByIsbn(Isbn isbn)
        {
            return ConvertToBookViewModel(_productRepo.GetBookByIsbn(isbn));
        }
        public List<BookViewModel> FilterByGenre(Genre genre)
        {
            return ConvertToBookViewModel(_productRepo.GetBooksByGenreId(genre.Id));
        }
/*
        //IEnumerable<Pet> query = pets.OrderBy(pet => pet.Age);
        public List<BookViewModel> SortByName(BookViewModel model)
        {
            List<BookViewModel> sortedList = model.OrderBy(item => item.Name).ToList();
            return sortedList;
        }

        public List<BookViewModel> SortByPrice(BookViewModel model)
        {
            return List<BookViewModel> sortedList = model.OrderBy(model => model.Price);
        }
        public List<BookViewModel> SortByAuthor(BookViewModel model)
        {
            return List<BookViewModel> sortedList = model.OrderBy(model => model.Author.Name);
        }
        */
    }
}
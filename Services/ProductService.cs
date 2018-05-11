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

        public List<BookViewModel> GetTop10()
        {
            var books = _productRepo.GetTop10();
            return ConvertToBookViewModel(books);
        }
        
        private List<BookViewModel> ConvertToBookViewModel(IEnumerable<Book> books)
        {
            return books.Select(book => GetBookById(book.Id)).ToList();
        }

        public BookViewModel GetBookById(int? id)
        {
            // Nothing else in the database
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

        private Product GetProduct(int? id)
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
        public List<BookViewModel> SearchByIsbn(string SearchString)
        {
                Isbn isbn = new Isbn(); 
                isbn.Isbn10 = SearchString;
                isbn.Isbn13 = SearchString;
                isbn.Asin = SearchString;
        
            return ConvertToBookViewModel(_productRepo.GetBookByIsbn(isbn));
        }
        public List<BookViewModel> FilterByGenre(Genre genre)
        {
            return ConvertToBookViewModel(_productRepo.GetBooksByGenreId(genre.Id));
        }

        public List<BookViewModel> SortByName()
        {
            var books = _productRepo.GetAllBooks();
            var sorted =  books.OrderBy(item => item.Name).ToList();
            var sortedView = ConvertToBookViewModel(sorted);
            return sortedView;
        }
        public List<BookViewModel> SortByPrice()
        {
            var books = _productRepo.GetAllBooks();
            var sorted =  books.OrderBy(item => item.Price).ToList();
            var sortedView = ConvertToBookViewModel(sorted);
            return sortedView;
        }
    }
}
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

        private List<BookViewModel> ConvertToBookViewModel(List<Book> books)
        {
            var viewModels = new List<BookViewModel>();
            foreach(Book book in books)
            {
            viewModels.Add(new BookViewModel
                {
                    Id = book.Id,
                    Price = book.Price,
                    Name = book.Name,
                    Image = book.Image,
                    Reviews = book.Reviews,
                    Description = book.Description,
                    Length = book.Length,
                    ReleaseDate = book.ReleaseDate,
                    Publisher = book.Publisher,
                    Isbn = book.Isbn,
                    BookLanguages = book.BookLanguages,
                    BookAuthors = book.BookAuthors,
                    BookGenres = book.BookGenres,
                    BookAgeGroups = book.BookAgeGroups
                }
            );
            }
            return viewModels;
        }
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
    }
}
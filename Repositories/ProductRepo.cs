using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class ProductRepo
    {
        private StoreContext _db = new StoreContext();

        public Product GetProduct(int id)
        {
            var product = from p in _db.Products where p.Id == id select p;
            return product.SingleOrDefault();
        }

        public List<Book> GetAllBooks()
        {
            var li = from b in _db.Books select b;
            return li.ToList();
        }

        public List<Book> GetBooksByAuthorId(int id)
        {
            var books = from bookAuthor in _db.BookAuthors
                join book in _db.Books on bookAuthor.BookId equals book.Id
                where bookAuthor.AuthorId == id
                select book;
            return books.ToList();
        }

        public List<Product> GetAllProducts()
        {
            var list = from p in _db.Products select p;
            return list.ToList();
        }

        public List<Author> GetAuthorByBookId(int id)
        {
            var authors = from a in _db.Authors
                join b in _db.BookAuthors on a.Id equals b.AuthorId
                where b.BookId == id
                select a;
            return authors.ToList();
        }

        public List<Paperback> GetPaperbacksByAuthor(int id)
        {
            var books = from a in _db.BookAuthors
                join b in _db.Paperbacks on a.BookId equals b.Id
                where a.BookId == id
                select b;
            return books.ToList();
        }

        public List<Paperback> GetAllPaperbacks()
        {
            return (from p in _db.Paperbacks select p).ToList();
        }

        public List<Hardcover> GetHardcoversByAuthor(int id)
        {
            var books = from a in _db.BookAuthors
                join b in _db.Hardcovers on a.BookId equals b.Id
                where a.BookId == id
                select b;
            return books.ToList();
        }

        public List<Hardcover> GetAllHardCovers()
        {
            return (from h in _db.Hardcovers select h).ToList();
        }

        public List<Audiobook> GetAudioBooksByAuthor(int id)
        {
            var books = from a in _db.BookAuthors
                join b in _db.AudioBooks on a.BookId equals b.Id
                where a.BookId == id
                select b;
            return books.ToList();
        }

        public List<Audiobook> GetAllAudioBooks()
        {
            return (from a in _db.AudioBooks select a).ToList();
        }

        public List<Ebook> GetEbooksByAuthor(int id)
        {
            var books = from a in _db.BookAuthors
                join b in _db.Ebooks on a.BookId equals b.Id
                where a.BookId == id
                select b;
            return books.ToList();
        }

        public List<Ebook> GetAllEbooks()
        {
            return (from e in _db.Ebooks select e).ToList();
        }

        public List<DigitalSheetMusic> GetDigitalSheetMusicByComposer(int id)
        {
            var music = from c in _db.SheetMusicComposers
                join s in _db.DigitalSheetMusics on c.SheetMusicId equals s.Id
                where c.ComposerId == id
                select s;
            return music.ToList();
        }

        public List<SheetMusic> GetSheetMusicByComposer(int id)
        {
            var music = from c in _db.SheetMusicComposers
                join m in _db.SheetMusics on c.SheetMusicId equals m.Id
                where c.ComposerId == id
                select m;
            return music.ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;

namespace BookCave.Repositories
{
    public class ProductRepo
    {
        private StoreContext _db = new StoreContext();
        private AuthorRepo _ar = new AuthorRepo();
        private NarratorRepo _nr = new NarratorRepo();

        public Product GetProduct(int id)
        {
            var product = from p in _db.Products where p.Id == id select p;
            return product.SingleOrDefault();
        }
        
        public List<Product> GetAllProducts()
        {
            var list = from p in _db.Products select p;
            return list.ToList();
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

        public List<Author> GetAuthorsByBookId(int id)
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

        public void CheckAuthor(List<Author> authors) //Listi af authors
        {
            foreach (var author in authors)
            {
                var checkAuthor = (from a in _ar.GetAllAuthors()
                    where a.FirstName == author.FirstName &&
                    a.LastName == author.LastName
                    select a);
                if(!checkAuthor.Any())
                {
                    var addAuthor = new AuthorInputModel
                    {
                        FirstName = author.FirstName,
                        LastName = author.LastName
                    };
                    _ar.AddAuthor(addAuthor);
                }
            }
        }
        private void CheckNarrator(List<Narrator> narrators)
        {
        foreach (var narrator in narrators)
            {
                var checkNarrator = (from n in _nr.GetAllNarrators()
                    where n.FirstName == narrator.FirstName &&
                    n.LastName == narrator.LastName
                    select n);
                if(!checkNarrator.Any())
                {
                    var addNarrator = new NarratorInputModel
                    {
                        FirstName = narrator.FirstName,
                        LastName = narrator.LastName
                    };
                    _nr.AddNarrator(addNarrator);
                }
            }
        }
        private bool CheckIsbn(Isbn isbn)
        {
            var check = (from i in _db.Books
                where i.Isbn == isbn
                select i);
            return check.Any();
        }
        //public void CheckNarrator()
        public void AddAudioBook(AudioBookInputModel book)
        {
            if(!CheckIsbn(book.Isbns))
            {
                CheckAuthor(book.Authors);
                CheckNarrator(book.Narrators);
                var audio = new Audiobook
                {
                    Price = book.Price,
                    Name = book.Name,
                    Image = book.Image,
                    Description = book.Description,
                    Length = book.Length,
                    Size = book.Size,
                    ReleaseDate = book.ReleaseDate,
                    Publisher = book.Publisher,
                    Isbn = book.Isbns,
                };

                audio.BookAgeGroups = new List<BookAgeGroup>();
                foreach (var ageGroup in book.AgeGroups)
                {
                    audio.BookAgeGroups.Add(new BookAgeGroup { Book = audio, AgeGroup = ageGroup });
                };
                audio.BookAuthors = new List<BookAuthor>();
                foreach (var author in book.Authors)
                {
                    audio.BookAuthors.Add(new BookAuthor { Book = audio, Author = author });
                };
                audio.BookGenres = new List<BookGenre>();
                foreach (var genre in book.Genres)
                {
                    audio.BookGenres.Add(new BookGenre { Book = audio, Genre = genre });
                };
                audio.BookLanguages = new List<BookLanguage>();
                foreach (var language in book.Languages)
                {
                    audio.BookLanguages.Add(new BookLanguage { Book = audio, Language = language });
                };
                audio.AudiobookNarrators = new List<AudiobookNarrator>();
                foreach (var narrator in book.Narrators)
                {
                    audio.AudiobookNarrators.Add(new AudiobookNarrator { Book = audio, Narrator = narrator });
                };
                _db.AudioBooks.AddRange(audio);
                _db.SaveChanges();
            }
        }
    }
}
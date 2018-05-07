using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;

namespace BookCave.Repositories
{
    public class ProductRepo
    {
        private StoreContext _db = new StoreContext();

        
        public List<Book> GetAllBooks()
        {
            var list = new List<Book>();
            list.AddRange(GetAllAudioBooks());
            list.AddRange(GetAllEbooks());
            list.AddRange(GetAllHardCovers());
            list.AddRange(GetAllPaperbacks());
            return list;
        }
        
        public List<Product> GetAllProducts()
        {
            var list = new List<Product>();
            list.AddRange(GetAllBooks());
            list.AddRange(GetAllSheetMusics());
            return list;
        }
        
        public List<Paperback> GetPaperbacksByAuthor(int id)
        {
            var books = from a in _db.BookAuthors
                join b in _db.Paperbacks on a.BookId equals b.Id
                where a.BookId == id
                select b;
            return books.ToList();
        }
        
        public Paperback GetPaperback(int id)
        {
            return (from p in _db.Paperbacks where p.Id == id select p).FirstOrDefault();
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
        
        public Hardcover GetHardcover(int id)
        {
            return (from h in _db.Hardcovers where h.Id == id select h).FirstOrDefault();
        }
        
        public List<Hardcover> GetAllHardCovers()
        {
            return (from h in _db.Hardcovers select h).ToList();
        }

        public List<AudioBook> GetAudioBooksByAuthor(int id)
        {
            var books = from a in _db.BookAuthors
                join b in _db.AudioBooks on a.BookId equals b.Id
                where a.BookId == id
                select b;
            return books.ToList();
        }
        
        public AudioBook GetAudioBook(int id)
        {
            return (from a in _db.AudioBooks where a.Id == id select a).FirstOrDefault();
        }
        
        public List<AudioBook> GetAllAudioBooks()
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
        public Ebook GetEbook(int id)
        {
            return (from e in _db.Ebooks where e.Id == id select e).FirstOrDefault();
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

        public DigitalSheetMusic GetDigitalSheetMusic(int id)
        {
            return (from d in _db.DigitalSheetMusics where d.Id == id select d).FirstOrDefault();
        }
        
        public List<DigitalSheetMusic> GetAllSheetMusics()
        {
            return (from s in _db.DigitalSheetMusics select s).ToList();
        }
        
        public PhysicalSheetMusic GetPhysicalSheetMusic(int id)
        {
            return (from d in _db.PhysicalSheetMusics where d.Id == id select d).FirstOrDefault();
        }
        
        public List<PhysicalSheetMusic> GetPhysicalSheetMusicByComposer(int id)
        {
            var music = from c in _db.SheetMusicComposers
                join s in _db.PhysicalSheetMusics on c.SheetMusicId equals s.Id
                where c.ComposerId == id
                select s;
            return music.ToList();
        }

        public List<PhysicalSheetMusic> GetAllPhysicalSheetMusics()
        {
            return (from p in _db.PhysicalSheetMusics select p).ToList();
        }

        public List<Book> GetBooksByAuthor(int id)
        {
            var books = new List<Book>();
            books.AddRange(GetAudioBooksByAuthor(id));
            books.AddRange(GetEbooksByAuthor(id));
            books.AddRange(GetPaperbacksByAuthor(id));
            books.AddRange(GetAllHardCovers());
            return books;
        }

        public List<SheetMusic> GetMusicByComposer(int id)
        {
            var music = new List<SheetMusic>();
            music.AddRange(GetDigitalSheetMusicByComposer(id));
            music.AddRange(GetPhysicalSheetMusicByComposer(id));
            return music;
        }
    }
}
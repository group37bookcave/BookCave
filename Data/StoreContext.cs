using System.Data.Common;
using BookCave.Models;
using BookCave.Models.EntityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Data
{
    public class StoreContext : DbContext
    {
        // The entity tables.

     
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Hardcover> Hardcovers { get; set; }
        public DbSet<Paperback> Paperbacks { get; set; }
        public DbSet<Audiobook> AudioBooks { get; set; }
        public DbSet<Ebook> Ebooks { get; set; }                
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Isbn> Isbns { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Narrator> Narrators { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<DigitalSheetMusic> DigitalSheetMusics { get; set; }
        public DbSet<PhysicalSheetMusic> PhysicalSheetMusics { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SheetMusic> SheetMusics { get; set; }

        
        // The many to many tables.
        public DbSet<BookAgeGroup> BookAgeGroups { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<SheetMusicComposer> SheetMusicComposers { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookLanguage> BookLanguages { get; set; }
        public DbSet<AudiobookNarrator> AudioBookNarrators { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CountryZipCode> CountryZipCodes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().ToTable("Products");
            //modelBuilder.Entity<Book>().ToTable("Books");
            //modelBuilder.Entity<SheetMusic>().ToTable("SheetMusics");
            
            // Configure many to many between Customer and Address.
            modelBuilder.Entity<CustomerAddress>().HasKey(ca => new {ca.CustomerId, ca.AddressId});
            
            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Customer)
                .WithMany(a => a.CustomerAddresses)
                .HasForeignKey(ca => ca.CustomerId);
            
            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Address)
                .WithMany(c => c.CustomerAddresses)
                .HasForeignKey(ca => ca.AddressId);
                       
            // Configure many to many between Book and AgeGroup.
            modelBuilder.Entity<BookAgeGroup>().HasKey(bag => new {bag.BookId, bag.AgeGroupId});
            
            modelBuilder.Entity<BookAgeGroup>()
                .HasOne(bag => bag.AgeGroup)
                .WithMany(b => b.BookAgeGroups)
                .HasForeignKey(bag => bag.AgeGroupId);
            
            modelBuilder.Entity<BookAgeGroup>()
                .HasOne(bag => bag.Book)
                .WithMany(b => b.BookAgeGroups)
                .HasForeignKey(bag => bag.BookId);
            
            // Configure many to many between Book and Author.
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new {ba.BookId, ba.AuthorId});
            
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
            
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);
            
            // Configure many to many between Book and Genre.
            modelBuilder.Entity<BookGenre>().HasKey(bg => new {bg.BookId, bg.GenreId});
            
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(ba => ba.GenreId);
            
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId);
            
            // Configure many to many between Book and Language.
            modelBuilder.Entity<BookLanguage>().HasKey(bl => new {bl.BookId, bl.LanguageId});
            
            modelBuilder.Entity<BookLanguage>()
                .HasOne(bl => bl.Language)
                .WithMany(b => b.BookLanguages)
                .HasForeignKey(bl => bl.LanguageId);
            
            modelBuilder.Entity<BookLanguage>()
                .HasOne(bl => bl.Book)
                .WithMany(b => b.BookLanguages)
                .HasForeignKey(bl => bl.BookId);
            
            // Configure many to many between AudioBook and Narrator.
            modelBuilder.Entity<AudiobookNarrator>().HasKey(bn => new {bn.AudiobookId, bn.NarratorId});
            
            modelBuilder.Entity<AudiobookNarrator>()
                .HasOne(bn => bn.Narrator)
                .WithMany(b => b.AudiobookNarrators)
                .HasForeignKey(bn => bn.NarratorId);
            
            modelBuilder.Entity<AudiobookNarrator>()
                .HasOne(bn => bn.Book)
                .WithMany(b => b.AudiobookNarrators)
                .HasForeignKey(bn => bn.AudiobookId);
            
            // Configure many to many between Country and ZipCode.
            modelBuilder.Entity<CountryZipCode>().HasKey(cz => new {cz.CountryId, cz.ZipCodeId});
            
            modelBuilder.Entity<CountryZipCode>()
                .HasOne(cz => cz.Country)
                .WithMany(c => c.CountryZipCodes)
                .HasForeignKey(cz => cz.CountryId);
            
            modelBuilder.Entity<CountryZipCode>()
                .HasOne(cz => cz.ZipCode)
                .WithMany(c => c.CountryZipCodes)
                .HasForeignKey(cz => cz.ZipCodeId);
            
            // Configure many to many between Sheetmusic and Composer.
            modelBuilder.Entity<SheetMusicComposer>().HasKey(sma => new {sma.SheetMusicId, sma.ComposerId});

            modelBuilder.Entity<SheetMusicComposer>()
                .HasOne(sma => sma.SheetMusic)
                .WithMany(s => s.SheetMusicComposers)
                .HasForeignKey(sma => sma.SheetMusicId);
            modelBuilder.Entity<SheetMusicComposer>()
                .HasOne(sma => sma.Composer)
                .WithMany(s => s.SheetMusicComposers)
                .HasForeignKey(sma => sma.ComposerId);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H37;Persist Security Info=False;User ID=VLN2_2018_H37_usr;Password=whi+ePig40;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }
       
    }
}
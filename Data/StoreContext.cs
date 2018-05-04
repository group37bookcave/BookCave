using BookCave.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Data
{
    public class StoreContext : DbContext
    {
        // The entity tables.
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Hardcover> Hardcovers { get; set; }
        public DbSet<Paperback> Paperbacks { get; set; }
        public DbSet<AudioBook> AudioBooks { get; set; }
        public DbSet<Ebook> Ebooks { get; set; }                
        // public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Isbn> Isbns { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Narrator> Narrators { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SheetMusic> SheetMusics { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }

        // The many to many tables.
        public DbSet<BookAgeGroup> BookAgeGroups { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookLanguage> BookLanguages { get; set; }
        public DbSet<EbookNarrator> EbookNarrators { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CountryZipCode> CountryZipCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Book>().ToTable("Books");
           /*
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasDiscriminator<int>("UserType")
                .HasValue<Customer>(1)
                .HasValue<Employee>(2);
            modelBuilder.Entity<Product>()
                .ToTable("Products")
                .HasDiscriminator<int>("ProductType")
                .HasValue<Book>(1)
                .HasValue<SheetMusic>(2);
           
            */
            
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
            
            modelBuilder.Entity<CustomerOrder>().HasKey(co => new {co.CustomerId, co.OrderId});
            
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
            
            /*
            // Configure many to many between Book and BookType.
            modelBuilder.Entity<BookBookType>().HasKey(bbt => new {bbt.BookId, bbt.BookTypeId});

            modelBuilder.Entity<BookBookType>()
                .HasOne(bbt => bbt.Book)
                .WithMany(b => b.BookBookTypes)
                .HasForeignKey(bbt => bbt.BookId);

            modelBuilder.Entity<BookBookType>()
                .HasOne(bbt => bbt.BookType)
                .WithMany(b => b.BookBookTypes)
                .HasForeignKey(bbt => bbt.BookTypeId);
            */
            
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
            
            // Configure many to many between Book and Narrator.
            modelBuilder.Entity<EbookNarrator>().HasKey(bn => new {bn.EbookId, bn.NarratorId});
            
            modelBuilder.Entity<EbookNarrator>()
                .HasOne(bn => bn.Narrator)
                .WithMany(b => b.BookNarrators)
                .HasForeignKey(bn => bn.NarratorId);
            
            modelBuilder.Entity<EbookNarrator>()
                .HasOne(bn => bn.Book)
                .WithMany(b => b.BookNarrators)
                .HasForeignKey(bn => bn.EbookId);
            
            // Configure many to many between Country and ZipCode
            modelBuilder.Entity<CountryZipCode>().HasKey(cz => new {cz.CountryId, cz.ZipCodeId});
            
            modelBuilder.Entity<CountryZipCode>()
                .HasOne(cz => cz.Country)
                .WithMany(c => c.CountryZipCodes)
                .HasForeignKey(cz => cz.CountryId);
            
            modelBuilder.Entity<CountryZipCode>()
                .HasOne(cz => cz.ZipCode)
                .WithMany(c => c.CountryZipCodes)
                .HasForeignKey(cz => cz.ZipCodeId);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H37;Persist Security Info=False;User ID=VLN2_2018_H37_usr;Password=whi+ePig40;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            );
        }
    }
}
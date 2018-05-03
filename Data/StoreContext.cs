using BookCave.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Isbn> Isbns { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Narrator> Narrators { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SheetMusic> SheetMusics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }
    }
}
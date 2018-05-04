using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using BookCave.Data;
using BookCave.Models.EntityModels;
using Microsoft.Extensions.DependencyInjection;


namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData()
        {
            var db = new StoreContext();

            if (!db.Admins.Any())
            {
                var admin = new Admin
                {
                    Email = "andreas.estensson@gmail.com",
                    IsActive = true,
                    Name = "Andreas Estensson",
                    Password = "hej"
                };
                db.Add(admin);
                db.SaveChanges();
            }

            if (!db.Customers.Any())
            {
                var cust = new Customer
                {
                    Email = "asas@sns.com",
                    Name = "John Doe",
                    Password = "JaneDoe",
                    IsActive = true
                };
                db.Add(cust);
                db.SaveChanges();
            }

            if (!db.Authors.Any())
            {
                var hardcover = new Hardcover
                {
                    Name = "Harry Potter and the Order of the Phoenix",
                    Description = "Harry is a wizard who has a scar in hi forehead",
                    Image = "https://media.bloomsbury.com/rep/f/9780747551003.jpg",
                    Publisher = new Publisher {Name = "Bloomsbury Publishing"},
                    Length = 768,
                    ReleaseDate = new DateTime(2003, 06, 21),
                    Price = 17.99,
                };
                
                
                var author = new Author {FirstName = "J.K", LastName = "Rowling"};
                hardcover.BookAuthors = new List<BookAuthor>
                {
                    new BookAuthor {Author = author, Book = hardcover}
                };
                hardcover.BookGenres = new List<BookGenre>
                {
                    new BookGenre {Book = hardcover, Genre = new Genre {Name = "Fantasy"}},
                    new BookGenre {Book = hardcover, Genre = new Genre {Name = "Children"}}
                };
                db.Books.Add(hardcover);
                db.SaveChanges();
            }
        }
    }
}
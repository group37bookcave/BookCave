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
                var hardcover_hp5 = new Hardcover
                {
                    Name = "Harry Potter and the Order of the Phoenix",
                    Description = "Harry is a wizard who has a scar in his forehead",
                    Image = "https://media.bloomsbury.com/rep/f/9780747551003.jpg",
                    Publisher = new Publisher {Name = "Bloomsbury Publishing"},
                    Length = 768,
                    ReleaseDate = new DateTime(2003, 06, 21),
                    Price = 17.99,
                };
                
                var paperback_hp5 = new Paperback
                {
                    Name = "Harry Potter and the Order of the Phoenix",
                    Description = "Dark times have come to Hogwarts. After the Dementors’ attack on his cousin Dudley, Harry Potter knows that Voldemort will stop at nothing to find him. There are many who deny the Dark Lord’s return, but Harry is not alone: a secret Order gathers at Grimmauld Place to fight against the Dark forces. Harry must allow Professor Snape to teach him how to protect himself from Voldemort’s savage assaults on his mind. But they are growing stronger by the day and Harry is running out of time.",
                    Image = "https://hpmedia.bloomsbury.com/rep/s/9781408855690_309036.jpeg",
                    Publisher = {Name = "Bloomsbury Publishing"},
                    Length = 816,
                    ReleaseDate = new DateTime(2014, 09, 01),
                    Price = 9.45,
                };
               
                
                var author = new Author {FirstName = "J.K", LastName = "Rowling"};
                hardcover_hp5.BookAuthors = new List<BookAuthor>
                {
                    new BookAuthor {Author = author, Book = hardcover_hp5}
                };
                
                paperback_hp5.BookAuthors = new List<BookAuthor>
                {
                    new BookAuthor {Author = author, Book = paperback_hp5}
                };
                
                hardcover_hp5.BookGenres = new List<BookGenre>
                {
                    new BookGenre {Book = hardcover_hp5, Genre = new Genre {Name = "Fantasy"}},
                    new BookGenre {Book = hardcover_hp5, Genre = new Genre {Name = "Children"}}
                };
                
                paperback_hp5.BookGenres = new List<BookGenre>
                {
                    new BookGenre {Book = paperback_hp5, Genre = new Genre {Name = "Fantasy"}},
                    new BookGenre {Book = paperback_hp5, Genre = new Genre {Name = "Children"}}
                };
                
                db.Books.Add(hardcover_hp5);
                db.SaveChanges();
                db.Books.Add(paperback_hp5);
                db.SaveChanges();
            }
        }
    }
}

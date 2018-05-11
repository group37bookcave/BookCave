using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Migrations.Store;
using BookCave.Models.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class WishListRepo
    {
        private readonly StoreContext _db = new StoreContext();

        public List<BookViewModel> GetWishList(int customerId)
        {
            var wishlist = GetCustomerWishList(customerId);
            var book = from b in _db.Books
                join w in wishlist.Products on b.Id equals w.ProductId
                select new BookViewModel
                {
                    Id = b.Id,
                    Image = b.Image,
                    Name = b.Name,
                    Format = b.GetType().Name,
                    Price = b.Price
                };
            return book.ToList();
        }

        public void AddToWishList(int productId, int customerId)
        {
            var wishlist = GetCustomerWishList(customerId);
            if (!Contains(productId, wishlist))
            {
                _db.WishListProducts.Add(new WishListProduct { ProductId = productId, WishListId = wishlist.Id});
            }
        }

        private WishList GetCustomerWishList(int customerId)
        {
            return (from w in _db.WishLists where w.CustomerId == customerId select w).SingleOrDefault();
        }

        private bool Contains(int productId, WishList wishList)
        {
            return wishList.Products.Any(item => item.ProductId == productId);
        }
    }
}
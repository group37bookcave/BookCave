using System.Collections.Generic;
using System.Data.Common;
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
            if (wishlist == null)
            {
                return null;
            }

            var book = from b in _db.Books
                join w in _db.WishListProducts on b.Id equals w.ProductId
                where w.WishListId == wishlist.Id
                select new BookViewModel
                {
                    Name = b.Name,
                    Image = b.Image,
                    Id = b.Id,
                    Price = b.Price,
                    Format = b.GetType().Name
                };
            return book.ToList();
        }

        public void AddToWishList(int productId, int customerId)
        {
            var wishlist = GetCustomerWishList(customerId);

            // No wishlist for this customer.
            if (wishlist == null)
            {
                wishlist = CreateWishList(customerId);
                _db.WishListProducts.Add(new WishListProduct {ProductId = productId, WishListId = wishlist.Id});
                _db.SaveChanges();
            }

            // The wishlist does not contain the item.
            else if (!Contains(productId, wishlist.Id))
            {
                _db.WishListProducts.Add(new WishListProduct {ProductId = productId, WishListId = wishlist.Id});
                _db.SaveChanges();
            }

            // The item is already in the wishlist, do nothing.
        }

        public void RemoveFromWishList(int productId, int customerId)
        {
            var wishlist = GetCustomerWishList(customerId);
            var item = (from w in _db.WishListProducts
                    where w.ProductId == productId && w.WishListId == wishlist.Id
                    select w)
                .SingleOrDefault();
            if (item == null)
            {
                return;
            }
            _db.WishListProducts.Remove(item);
            _db.SaveChanges();
        }

        private WishList CreateWishList(int customerId)
        {
            var wishlist = new WishList {CustomerId = customerId};
            _db.WishLists.Add(wishlist);
            _db.SaveChanges();
            return wishlist;
        }

        private WishList GetCustomerWishList(int customerId)
        {
            return (from w in _db.WishLists where w.CustomerId == customerId select w).SingleOrDefault();
        }

        private bool Contains(int productId, int wishListId)
        {
            return (from w in _db.WishListProducts
                where productId == w.ProductId && wishListId == w.WishListId
                select w).Any();
        }
    }
}
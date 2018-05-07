using System;
using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.EntityModels;
using BookCave.Models.InputModels;
using Microsoft.EntityFrameworkCore.Query.Sql.Internal;

namespace BookCave.Repositories
{
    public class ReviewRepo
    {
        private readonly StoreContext _db = new StoreContext();
        private readonly UserRepo _ur = new UserRepo();
        private readonly ProductRepo _pr = new ProductRepo();

        public List<Review> GetReviewsByCustomerId(int id)
        {
            var reviews = from r in _db.Reviews where r.Customer.Id == id select r;
            return reviews.ToList();
        }

        public List<Review> GetReviewsByProductId(int id)
        {
            var reviews = from r in _db.Reviews where r.Product.Id == id select r;
            return reviews.ToList();
        }

        public void AddReviewToProduct(ReviewInputModel model)
        {
            var review = new Review
            {
                Customer = _ur.GetCustomer(model.CustomerId),
                DateReviewed = DateTime.Today,
                Product = _pr.GetProduct(model.ProductId),
                Rating = model.Rating,
                ReviewString = model.Review
            };
            _db.Add(review);
            _db.SaveChanges();
        }
    }
}
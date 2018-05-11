namespace BookCave.Models.EntityModels
{
    public class WishListProduct
    {
        public WishList WishList { get; set; }

        public int WishListId { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
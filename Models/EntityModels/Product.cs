
namespace BookCave.Models.EntityModels
{
    public abstract class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public ProductType ProductType { get; set; }
    }
}
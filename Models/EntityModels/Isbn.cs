namespace BookCave.Models.EntityModels
{
    public class Isbn
    {
        public int Id { get; set; }

        public string Isbn10 { get; set; }
        
        public string Isbn13 { get; set; }
        
        public string Asin { get; set; }
    }
}
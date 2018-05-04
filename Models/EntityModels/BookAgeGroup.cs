namespace BookCave.Models.EntityModels
{
    public class BookAgeGroup
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int AgeGroupId { get; set; }

        public AgeGroup AgeGroup { get; set; }
    }
}
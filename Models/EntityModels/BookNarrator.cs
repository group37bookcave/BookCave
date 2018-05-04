namespace BookCave.Models.EntityModels
{
    public class EbookNarrator
    {
        public int EbookId { get; set; }

        public Ebook Book { get; set; }

        public int NarratorId { get; set; }

        public Narrator Narrator { get; set; }
    }
}
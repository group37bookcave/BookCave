namespace BookCave.Models.EntityModels
{
    public class AudiobookNarrator
    {
        public int AudiobookId { get; set; }

        public Audiobook Book { get; set; }

        public int NarratorId { get; set; }

        public Narrator Narrator { get; set; }
    }
}
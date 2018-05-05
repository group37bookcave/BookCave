namespace BookCave.Models.EntityModels
{
    public class SheetMusicComposer
    {
        public int SheetMusicId { get; set; }

        public SheetMusic SheetMusic { get; set; }

        public int ComposerId { get; set; }

        public Composer Composer { get; set; }
    }
}
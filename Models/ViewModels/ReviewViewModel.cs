namespace BookCave.Models.ViewModels
{
    public class ReviewViewModel
    {
        public string Review { get; set; }
        public int Rating { get; set; }
        public CustomerViewModel ReviewedBy { get; set; }
    }
}
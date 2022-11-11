namespace Mobile_Project_Api.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewDescription { get; set; }
        public string GameImageId { get; set; }
        public int GameId { get; set; }
        public string GameNaam { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
    }
}

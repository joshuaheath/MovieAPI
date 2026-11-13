namespace MovieAPI.DTO
{
    public class CriticReview
    {
        public int id {  get; set; }

        //FK
        public Movie movie { get; set; } = null!;

        public string description { get; set; } = string.Empty;

        public int rating { get; set; }

        public bool isPublished { get; set; } = false;

        public string createdBy { get; set; } = string.Empty;

        public DateTime createdDate { get; set; } = DateTime.Now;
    }
}

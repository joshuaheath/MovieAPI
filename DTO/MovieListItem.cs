namespace MovieAPI.DTO
{
    public class MovieListItem
    {
        public int id { get; set; }
        public Genre genre { get; set; } = null!;
        public AudienceRating audienceRating { get; set; } = null!;
        public string title { get; set; }
        public string runtimeMin { get; set; }
        public string synopsis { get; set; }
        public string imageUrl { get; set; }
        public DateOnly releaseDate { get; set; }
    }
}

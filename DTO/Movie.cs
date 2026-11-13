using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieAPI.DTO
{
    public class Movie
    {
        public int id { get; set; }
        public int genreid { get; set; }

        public int audienceRatingid { get; set; }

        //Navigation propertys
        public Genre genre { get; set; } = null!;

        public AudienceRating audienceRating { get; set; } = null!;
        public string title { get; set; }
        public string runtimeMin { get; set; }
        public string synopsis { get; set; }
        public string imageUrl { get; set; }

        public DateOnly releaseDate { get; set; }

    }
}

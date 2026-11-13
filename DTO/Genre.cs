using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTO
{
    public class Genre
    {
        public int id { get; set; }

        // navigation property
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public string title { get; set; } = string.Empty;
    }
}

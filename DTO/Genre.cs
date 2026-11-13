using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTO
{
    public class Genre
    {
        public int id { get; set; }

        public string title { get; set; } = string.Empty;
    }
}

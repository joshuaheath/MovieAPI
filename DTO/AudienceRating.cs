using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTO
{
    public class AudienceRating
    {
        public int id { get; set; }

        // navigation property
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public string title { get; set; } = string.Empty;
    }
}

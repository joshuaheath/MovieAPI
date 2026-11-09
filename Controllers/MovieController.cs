using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        public MovieController()
        { 

        }
        private static readonly string[] titles = { "title 1", "title 2", "title 3" };
            private static readonly string[] audienceRating = {"E", "M", "PG-13" };
            private static readonly string[] genres = {"Horror", "Sci-fi", "Comedy" };
            private static readonly string[] synopsis = {"Desc 1", "Desct 2", "Desc 3" };


        [HttpGet(Name = "GetMovies")]
        public IEnumerable<Movie> Get()
        {
            return Enumerable.Range(1, 6)
                .Select(index => new Movie
                {
                    Id = Random.Shared.Next(1, 10),
                    Title = titles[(Random.Shared.Next(titles.Length))],
                    Synopsis = synopsis[Random.Shared.Next(synopsis.Length)],
                    Genre = genres[Random.Shared.Next(genres.Length)],
                    AudienceRating = audienceRating[Random.Shared.Next(audienceRating.Length)],
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    ReviewCount = Random.Shared.Next(1, 10)
                })
                .ToArray();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        //{

        //}


        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}

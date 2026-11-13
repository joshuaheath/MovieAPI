using Dapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.DTO;
using System.Data;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IDbConnection _db;
        public MovieController(IDbConnection db)
        {
            _db = db;
        }

        // GET/api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            var sql = @"SELECT m.*, g.*, ar.*
                FROM Movie m 
                INNER JOIN Genre g ON m.genreid = g.id
                INNER JOIN AudienceRating ar ON m.audienceRatingid = ar.id";

            // Fetch all trails from database. <Table 1, Table 2, Table 3, Output>
            var movies = await _db.QueryAsync<Movie, Genre, AudienceRating, Movie>(
                sql,
                (movie, genre, audienceRating) =>
                {
                    movie.genre = genre;
                    movie.audienceRating = audienceRating;
                    return movie;
                });
            return Ok(movies);
        }

    }
}

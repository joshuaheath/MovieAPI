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
            var sql = @"SELECT m.*, cr.*
                FROM Movie m 
                INNER JOIN CriticReview cr ON m.criticReviews = c.Id";

            // Fetch all trails from database. <Table 1, Table 2, Output>
            var movies = await _db.QueryAsync<Movie, CriticReview, Movie>(
                sql,
                (movies, genres, ) =>
                {
                    trail.Category = category;
                    return trail;
                });
            return Ok(movies);
        }

    }
}

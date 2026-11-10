using Dapper;
using Microsoft.AspNetCore.Mvc;
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
            var movies = await _db.QueryAsync<Movie>(
                "SELECT * FROM Movie");

            return Ok(movies);
        }

    }
}

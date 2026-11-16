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


        // GET /api/movies/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovieById(int id)
        {
            var sql = @"SELECT m.*, g.*, ar.*, cr.*, us.*
                FROM Movie m 
                INNER JOIN Genre g ON m.genreid = g.id
                INNER JOIN AudienceRating ar ON m.audienceRatingid = ar.id
                LEFT OUTER JOIN CriticReview cr ON m.id = cr.movieId
                LEFT OUTER JOIN UserSnapshot us ON cr.createdBy = us.UserId
                WHERE m.id = @id";

            //Create a trail
            Movie ? movie = null;
            // Fetch all trails from database. <Table 1, Table 2, Table 3, Table 4, Table 5, Output>
            await _db.QueryAsync<Movie, Genre, AudienceRating, CriticReview, UserSnaphot, Movie>(
                sql,
                (m, g, ar, cr, us) =>
                {
                    // populate movie
                    if(movie == null)
                    {
                        movie = m;
                        movie.genre = g;
                        movie.audienceRating = ar;
                        movie.reviews = new List<CriticReview>(); //initilize empty list
                    }

                    if(cr != null)
                    {
                        if (cr.isPublished)
                        {
                            cr.user = us;
                            movie.reviews.Add(cr);
                        }
                    }

                    return movie;
                },
                new {id =  id},
                splitOn: "id,id,userId"
                );
            return Ok(movie);

        }

    }
}

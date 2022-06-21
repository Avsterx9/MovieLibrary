using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Entities;
using System.Collections.Generic;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("api/movieLibrary")]
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext dbContext;
        public MovieController(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            var movies = dbContext.Movies
                .Include(a => a.Actors)
                .ToListAsync();

            return Ok(await movies);
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddMovie(Movie movie)
        {
            dbContext.Movies.Add(movie);
            await dbContext.SaveChangesAsync();

            var movies = dbContext.Movies
                .Include(a => a.Actors)
                .ToListAsync();

            return Ok(await movies);
        }

    }
}

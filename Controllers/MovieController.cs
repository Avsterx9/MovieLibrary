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
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            return Ok(await dbContext.Movies.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddNewMovie()
        {
            return Ok(await dbContext.Movies.ToListAsync());
        }

    }
}

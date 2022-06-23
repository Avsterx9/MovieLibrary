using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.DtoModels;
using MovieLibrary.Entities;
using System.Collections.Generic;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("api/movieLibrary")]
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext dbContext;
        private readonly IMapper mapper;
        public MovieController(MovieDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            var movies = dbContext.Movies
                .Include(a => a.Actors)
                .ToListAsync();

            return Ok(await movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetById(int id)
        {
            var movie = dbContext.Movies
                .Include(a => a.Actors)
                .SingleOrDefault(a => a.Id == id);

            if(movie != null)
            {
                return Ok(movie);
            }

            return NotFound("Movie not Found");
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(CreateMovieDto movieDto)
        {
            var movie = mapper.Map<Movie>(movieDto);
            dbContext.Movies.Add(movie);
            await dbContext.SaveChangesAsync();

            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var movie = await dbContext.Movies.FindAsync(id);

            if (movie == null)
                return NotFound("Movie not Found");


            dbContext.Movies.Remove(movie);
            await dbContext.SaveChangesAsync();
            return Ok("Movie successfuly deleted");
        }

    }
}

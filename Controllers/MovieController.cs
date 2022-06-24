using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.DtoModels;
using MovieLibrary.Entities;
using MovieLibrary.Services;
using System.Collections.Generic;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("api/movieLibrary")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return Ok(movieService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            var movie = movieService.GetById(id);

            if(movie is null)
            {
                return NotFound("Movie not Found");
            }
            return Ok(movie);
        }

        [HttpPost]
        public ActionResult AddMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            movieService.Create(movieDto);
            return Ok("Movie has been added");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var isRemoved = movieService.DeleteById(id);

            if (!isRemoved)
                return NotFound("Movie not Found");

            return Ok("Movie successfuly deleted");
        }

        [HttpPut("{id}")]
        public ActionResult<Movie> UpdateMovie(int id, MovieDto movieDto)
        {
            var movie = movieService.UpdateMovie(id, movieDto);

            if (movie == null)
                return NotFound("Movie not Found");

            return Ok(movie);
        }
    }
}

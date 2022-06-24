using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.DtoModels;
using MovieLibrary.Entities;

namespace MovieLibrary.Services
{
    public interface IMovieService
    {
        void Create(MovieDto dto);
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        bool DeleteById(int id);
        Movie UpdateMovie(int id, MovieDto dto);
    }

    public class MovieService : IMovieService
    {
        private readonly MovieDbContext dbContext;
        private readonly IMapper mapper;

        public MovieService(MovieDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public Movie GetById(int id)
        {
            var movie = dbContext.Movies
                .Include(a => a.Actors)
                .SingleOrDefault(a => a.Id == id);

            return movie;
        }

        public IEnumerable<Movie> GetAll()
        {
            var movies = dbContext.Movies
                .Include(a => a.Actors)
                .ToList();

            return movies;
        }

        public void Create(MovieDto dto)
        {
            var movie = mapper.Map<Movie>(dto);
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
        }

        public bool DeleteById(int id)
        {
            var movie = dbContext.Movies.Find(id);

            if (movie is null)
                return false;

            dbContext.Movies.Remove(movie);
            dbContext.SaveChanges();
            return true;
        }

        public Movie UpdateMovie(int id, MovieDto dto)
        {
            var movie = dbContext.Movies.Find(id);

            if (movie is null)
                return null;

            movie.Title = dto.Title;
            movie.Description = dto.Description;
            movie.Category = dto.Category;
            movie.ReleaseDate = dto.ReleaseDate;
            movie.ImgSrc = dto.ImgSrc;

            dbContext.SaveChanges();

            return movie;
        }

    }
}

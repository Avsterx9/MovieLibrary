using AutoMapper;
using MovieLibrary.DtoModels;
using MovieLibrary.Entities;

namespace MovieLibrary.Profiles
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            // Src -> destination
            CreateMap<MovieDto, Movie>();
        }

    }
}

using MovieLibrary.Entities;

namespace MovieLibrary.DtoModels
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImgSrc { get; set; }
    }
}

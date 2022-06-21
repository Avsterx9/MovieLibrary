namespace MovieLibrary.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImgSrc { get; set; }
        public virtual ICollection<Actor> Actors  { get; set; }
    }
}

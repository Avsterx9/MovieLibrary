using Microsoft.EntityFrameworkCore;

namespace MovieLibrary.Entities
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(eb =>
            {
                eb.Property(wi => wi.Title).HasMaxLength(50);
                eb.Property(wi => wi.Description).HasMaxLength(200);
                eb.Property(wi => wi.ImgSrc).HasColumnName("Img_Src");
                eb.Property(wi => wi.ReleaseDate).HasColumnName("Release_Date");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MovieLibraryConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

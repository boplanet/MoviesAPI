using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
    public class MoviesAPIdbContext : DbContext
    {
        public MoviesAPIdbContext(DbContextOptions<MoviesAPIdbContext> options) :
       base(options)
        { }
        public DbSet<MoviesAPI.Data.Movie> Movie { get; set; }
    }
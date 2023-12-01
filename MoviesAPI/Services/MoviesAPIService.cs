using System;
using MoviesAPI.Data;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Services
{
    public class MoviesAPIService
    {
        private MoviesAPIdbContext _context;
        public MoviesAPIService(MoviesAPIdbContext context)
        {
            _context = context;
        }
        public void AddMovie(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Year = movie.Year,
                Genre = movie.Genre,
            };
            _context.Movie.Add(newMovie);
            _context.SaveChanges();
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Services
{
    public class MoviesAPIService
    {
        private readonly MoviesAPIdbContext _context;

        public MoviesAPIService(MoviesAPIdbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> DohvatiSveFilmove()
        {
            return _context.Movie.ToList();
        }
        /*ili bolje
        public IQueryable<Movie> GetAllMovies()
        {
            return _context.Movie.AsQueryable();
        }*/

        public Movie DohvatiFilmPoId(int id)
        {
          
                return _context.Movie.FirstOrDefault( m => m.Id == id);
        }
        /*Ili makne se u cotroleru opcija provjere null
         public IActionResult DohvatiFilmPoId(int id)
        {
            var mf = _context.Movie.FirstOrDefault(m => m.Id == id);

            if (mf != null)
            {
                return new OkObjectResult(mf);
            }

            return new NotFoundResult();
        }
         */

        public void UpdateMovie(int id, MovieVM updatedMovie)
        {
            var existingMovie = _context.Movie.FirstOrDefault(m => m.Id == id);

            if (existingMovie != null)
            {
                existingMovie.Name = updatedMovie.Name;
                existingMovie.Year = updatedMovie.Year;
                existingMovie.Genre = updatedMovie.Genre;

                _context.SaveChanges();
            }
        }

        public void DeleteMovie(int id)
        {
            var movieToDelete = _context.Movie.FirstOrDefault(m => m.Id == id);

            if (movieToDelete != null)
            {
                _context.Movie.Remove(movieToDelete);
                _context.SaveChanges();
            }
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


using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;
using MoviesAPI.ViewModels;
using System.Linq;

[ApiController]
[Route("api/Movie")]
public class MoviesAPIController : ControllerBase
{
    private readonly MoviesAPIdbContext _dbContext;
    private readonly MoviesAPIService _moviesAPIService;

    public MoviesAPIController(MoviesAPIdbContext dbContext, MoviesAPIService moviesAPIService)
    {
        _dbContext = dbContext;
        _moviesAPIService = moviesAPIService;
    }

    // Dohvaćanje svih filmova
    [HttpGet]
    public IActionResult DohvatiSveFilmove()
    {
        var filmovi = _dbContext.Movie.ToList();
        return Ok(filmovi);
    }

    // Dohvaćanje filma preko ID-a
    [HttpGet("{id}")]
    public IActionResult DohvatiFilmPoId(int id)
    {
        var film = _dbContext.Movie.FirstOrDefault(f => f.Id == id);

        if (film == null)
        {
            return NotFound();
        }

        return Ok(film);
    }

    // Ažuriranje filma
    [HttpPut("{id}")]
    public IActionResult AzurirajFilm(int id, [FromBody] MovieVM noviPodaci)
    {
        var stariFilm = _dbContext.Movie.FirstOrDefault(f => f.Id == id);

        if (stariFilm == null)
        {
            return NotFound();
        }
        stariFilm.Name = noviPodaci.Name;
        stariFilm.Year = noviPodaci.Year;
        stariFilm.Genre = noviPodaci.Genre;

        _dbContext.SaveChanges();

        return NoContent();
    }

    // Brisanje filma
    [HttpDelete("{id}")]
    public IActionResult ObrisiFilm(int id)
    {
        var film = _dbContext.Movie.FirstOrDefault(f => f.Id == id);

        if (film == null)
        {
            return NotFound();
        }

        _dbContext.Movie.Remove(film);
        _dbContext.SaveChanges();

        return NoContent();
    }

    // Dodavanje filma
    [HttpPost]
    public IActionResult DodajFilm([FromBody] MovieVM noviFilm)
    {
        _moviesAPIService.AddMovie(noviFilm);

        return CreatedAtAction(nameof(DohvatiFilmPoId), new { id = noviFilm.Id }, noviFilm);
    }
}

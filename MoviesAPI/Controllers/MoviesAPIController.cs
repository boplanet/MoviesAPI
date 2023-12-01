using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;
using MoviesAPI.ViewModels;
using System.Linq;

[ApiController]
[Route("api/Movie")]
public class MoviesAPIController : ControllerBase
{
    private readonly MoviesAPIService _moviesAPIService;

    public MoviesAPIController(MoviesAPIService moviesAPIService)
    {
        _moviesAPIService = moviesAPIService;
    }

    // Dohvaćanje svih filmova
    [HttpGet]
    public IActionResult DohvatiSveFilmove()
    {
        var filmovi = _moviesAPIService.DohvatiSveFilmove();
        return Ok(filmovi);
    }

    // Dohvaćanje filma preko ID-a
    [HttpGet("{id}")]
    public IActionResult DohvatiFilmPoId(int id)
    {
        var film = _moviesAPIService.DohvatiFilmPoId(id);
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
        _moviesAPIService.UpdateMovie(id, noviPodaci);
        return NoContent();
    }

    // Brisanje filma
    [HttpDelete("{id}")]
    public IActionResult ObrisiFilm(int id)
    {
        _moviesAPIService.DeleteMovie(id);
        return NoContent();
    }

    // Dodavanje filma kroz servis
    [HttpPost]
    public IActionResult DodajFilm([FromBody] MovieVM noviFilm)
    {
        _moviesAPIService.AddMovie(noviFilm);
        return CreatedAtAction(nameof(DohvatiFilmPoId), new { id = noviFilm.Id }, noviFilm);
    }
}


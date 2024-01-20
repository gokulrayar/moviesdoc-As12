// Controllers/MoviesController.cs 
using As12Doc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private static List<Movies> _movies = new List<Movies>
    {
        new Movies { Id = 1, MovieName = "Inception", Genere = "Sci-Fi", year = 2010 },
        new Movies { Id = 2, MovieName = "The Shawshank Redemption", Genere = "Drama", year = 1994 }
    };

    // GET: api/movies
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_movies);
    }

    // GET: api/movies/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    // POST: api/movies
    [HttpPost]
    public IActionResult Post([FromBody] Movies movie)
    {
        movie.Id = _movies.Count + 1;
        _movies.Add(movie);
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    // PUT: api/movies/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Movies updatedMovie)
    {
        var existingMovie = _movies.FirstOrDefault(m => m.Id == id);
        if (existingMovie == null)
        {
            return NotFound();
        }

        existingMovie.MovieName = updatedMovie.MovieName;
        existingMovie.Genere = updatedMovie.Genere;
        existingMovie.year = updatedMovie.year;

        return NoContent();
    }

    // DELETE: api/movies/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        _movies.Remove(movie);
        return NoContent();
    }
}
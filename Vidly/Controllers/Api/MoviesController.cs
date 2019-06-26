using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]        
        public IHttpActionResult getMovies()
        {
            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDtos>);
            if (movies == null)
                return NotFound();

            return Ok(movies);            
        }

        [HttpGet]
        public IHttpActionResult getMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDtos>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDtos movieDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDtos, Movie>(movieDtos);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDtos);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDtos movieDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            var movie = Mapper.Map<MovieDtos, Movie>(movieDtos);
            movieInDb.Id = movieDtos.Id;
            _context.SaveChanges();

            return Ok();
        }
    }
}

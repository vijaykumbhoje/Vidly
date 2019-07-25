using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
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
        public IHttpActionResult GetMovies(string movie= null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre).Where(m => m.AvailableStock > 0);

            if (!String.IsNullOrEmpty(movie))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(movie));   
            
            var moviesDtos = moviesQuery                 
                .ToList()
                .Select(Mapper.Map<Movie, MovieDtos>);
            if (moviesDtos == null)
                return NotFound();

            return Ok(moviesDtos);            
        }

        [HttpGet]
        public IHttpActionResult GetMovie(int id)
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
            movie.DateCreated = DateTime.Now;
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

            Mapper.Map(movieDtos, movieInDb);          

            return Ok(_context.SaveChanges());
        }

        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
           return Ok(_context.SaveChanges());
        }
    }
}

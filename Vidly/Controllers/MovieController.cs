using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var mvs = _context.Movies.Include(m=>m.Genre).ToList();
            return View(mvs);          
        }

        public ActionResult Details(int id)
        {
            var movieDetails = _context.Movies.Include(g => g.Genre).FirstOrDefault(m=>m.Id==id);
            return View(movieDetails);
        }

        public ActionResult NewMovie()
        {
            var genres = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genre = genres
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m=>m.Id==id);
            if (movie.Id == 0)
                return HttpNotFound();
            else
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    
                    Genre = _context.Genre.ToList()
                };
                return View("NewMovie", viewModel);
            }            
        }

        /// <summary>
        /// http post 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateCreated = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.DateReleased = movie.DateReleased;
                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.Stock = movie.Stock;
                MovieInDb.DateCreated = movie.DateCreated;    
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

    }
}
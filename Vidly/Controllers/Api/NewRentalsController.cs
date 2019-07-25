using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
      
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
         
       

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDtos rentalDto)
        {
            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);
            var Movies = _context.Movies.Where(m => rentalDto.MovieId.Contains(m.Id)).ToList();
            foreach(var movie in Movies)
            {
                if (movie.AvailableStock == 0)
                    return BadRequest(movie.Name + "is running out of stock.");
                movie.AvailableStock--;
                    Rental rental = new Rental
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = DateTime.Now
                    };
                    _context.Rental.Add(rental);                                 
            }
            _context.SaveChanges();
            return Ok();
          
        }
    }
}

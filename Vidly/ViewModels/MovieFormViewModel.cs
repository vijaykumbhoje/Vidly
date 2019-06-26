using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre{ get; set; }
        public int? Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Date Released")]
        public DateTime? DateReleased { get; set; }

        [Required]
        [Range(1, 20)]
        public int? Stock { get; set; }
       
        [Required]
        public int? GenreId { get; set; }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Stock = movie.Stock;
            DateReleased = movie.DateReleased;
            GenreId = movie.GenreId;
        }
    }
}
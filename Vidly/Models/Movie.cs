using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        [Required]
        [Display(Name="Date Released")]
        public DateTime DateReleased { get; set; }

        [Required]
        public DateTime? DateCreated { get; set; }

        [Required]
        [Range(1,20)]
        public int Stock { get; set; }
       
        public Genre Genre { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}
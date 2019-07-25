using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDtos
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
       
        public DateTime DateReleased { get; set; }

       
        public DateTime? DateCreated { get; set; }

        [Required]
        [Range(1, 20)]
        public int Stock { get; set; }

        public GenreDtos Genre { get; set; }

        public Byte GenreId { get; set; }
    }
}
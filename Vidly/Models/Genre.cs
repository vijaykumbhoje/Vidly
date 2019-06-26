using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string NameOfGenre { get; set; }

    }
}
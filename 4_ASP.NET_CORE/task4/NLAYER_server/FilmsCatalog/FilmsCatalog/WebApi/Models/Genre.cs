using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCtalog.WebApi.Models
{
    public class Genre
    {
        [Required]
        public string GenreName { get; set; }
    }
}

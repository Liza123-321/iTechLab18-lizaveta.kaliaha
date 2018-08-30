using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCtalog.WebApi.Models
{
    public class GenreWithFilm
    {
        public string GenreName { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}

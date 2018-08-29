using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.Business.Models
{
   public class GenreWithFilm
    {
        public string GenreName { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}

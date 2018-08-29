using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.Business.Models
{
   public class GenreWithFilmModel
    {
        public string GenreName { get; set; }
        public ICollection<FilmModel> Films { get; set; }
    }
}

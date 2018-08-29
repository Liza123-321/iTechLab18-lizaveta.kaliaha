using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCtalog.WebApi.Models
{
    public class GenreWithFilmViewModel
    {
        public string GenreName { get; set; }
        public ICollection<FilmViewModel> Films { get; set; }
    }
}

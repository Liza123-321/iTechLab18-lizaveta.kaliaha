using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.Business.Models
{
   public class FilmWithGenresModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Producer { get; set; }
        public string Poster { get; set; }
        public int Year { get; set; }
        public string Video { get; set; }
        public ICollection<GenreModel> Genres { get; set; }
    }
}

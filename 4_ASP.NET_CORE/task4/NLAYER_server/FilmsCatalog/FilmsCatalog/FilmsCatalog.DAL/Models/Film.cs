﻿using System.Collections.Generic;

namespace FilmsCatalog.DAL.Models
{
    public class Film
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
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.DAL.Models
{
    public class RatingMark
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public int FilmId { get; set; }
        public int UserId { get; set; }
        public Film Film { get; set; }
        public User User { get; set; }
    }
}

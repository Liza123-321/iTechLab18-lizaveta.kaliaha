using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.Business.Models
{
    public class RatingModel
    {
        public int Mark { get; set; }
        public int FilmId { get; set; }
        public int UserId { get; set; }
    }
}

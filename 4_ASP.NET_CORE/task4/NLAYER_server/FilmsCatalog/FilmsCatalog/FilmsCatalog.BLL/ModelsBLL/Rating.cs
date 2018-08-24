using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.BLL.ModelsBLL
{
    public class Rating
    {
        public int Mark { get; set; }
        public int FilmId { get; set; }
        public int UserId { get; set; }
    }
}

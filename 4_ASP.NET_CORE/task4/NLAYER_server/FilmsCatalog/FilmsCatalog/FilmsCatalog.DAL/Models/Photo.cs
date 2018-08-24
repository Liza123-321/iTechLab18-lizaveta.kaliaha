using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.DAL.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public Film Film { get; set; }
        public int FilmId { get; set; }
    }
}

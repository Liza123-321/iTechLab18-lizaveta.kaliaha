using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Models
{
    public class RatingDTO
    {
        public int Mark { get; set; }
        public int FilmId { get; set; }
        public int UserId { get; set; }
    }
}

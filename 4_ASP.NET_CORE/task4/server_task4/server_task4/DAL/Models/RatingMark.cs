using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.DAL.Models
{
    public class RatingMark
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public Film Film { get; set; }
        public User User { get; set; }
    }
}

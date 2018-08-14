using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.DAL.Models
{
    public class Film
    {
        public int Id { get; set; }
        public double AverageRating { get; set; }
        public string Description { get; set; }
        public List<Gallery> Photos { get; set; }
    }
}

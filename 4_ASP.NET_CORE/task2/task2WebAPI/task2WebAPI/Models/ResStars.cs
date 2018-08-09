using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2WebAPI.Models
{
    public class ResStars
    {
        public int? Count { get; set; }
        public List<Star> Results { get; set; }
        public ResStars()
        {
            this.Count = 0;
            this.Results = new List<Star>();
        }
    }
}

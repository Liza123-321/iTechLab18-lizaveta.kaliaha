using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2WebAPI.Models
{
    public class ResStarsNext
    {
        public string Next { get; set; }
        public int Count { get; set; }
        public List<Star> Results { get; set; }
    }
}

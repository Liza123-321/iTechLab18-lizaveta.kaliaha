using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.DAL.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public Film Film { get; set; }
        public string PhotoUrl { get; set; }
    }
}

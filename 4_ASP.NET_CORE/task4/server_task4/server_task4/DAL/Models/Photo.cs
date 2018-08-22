using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.DAL.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public Film Film { get;set; }
        public int FilmId { get; set; }
    }
}

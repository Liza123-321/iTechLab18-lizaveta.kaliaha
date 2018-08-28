using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCtalog.WebApi.Models
{
    public class RatingViewModel
    {
        [Required]
        public int Mark { get; set; }
        [Required]
        public int FilmId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}

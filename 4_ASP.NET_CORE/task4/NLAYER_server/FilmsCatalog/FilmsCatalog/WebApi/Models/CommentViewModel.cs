using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCtalog.WebApi.Models
{
    public class CommentViewModel
    {
        [Required]
        public string CommentMessage { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int FilmId { get; set; }
        [Required]
        public string Data { get; set; }

    }
}

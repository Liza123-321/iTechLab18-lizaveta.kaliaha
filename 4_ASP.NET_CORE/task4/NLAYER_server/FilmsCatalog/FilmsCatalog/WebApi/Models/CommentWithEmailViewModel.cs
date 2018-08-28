using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCtalog.WebApi.Models
{
    public class CommentWithEmailViewModel
    {
        public string CommentMessage { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string Data { get; set; }
        public string Email { get; set; }
    }
}

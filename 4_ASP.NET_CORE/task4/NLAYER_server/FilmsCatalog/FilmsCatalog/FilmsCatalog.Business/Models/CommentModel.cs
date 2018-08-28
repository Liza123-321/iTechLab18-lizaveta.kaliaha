using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.Business.Models
{
   public class CommentModel
    {
        public string CommentMessage { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string Data { get; set; }
    }
}

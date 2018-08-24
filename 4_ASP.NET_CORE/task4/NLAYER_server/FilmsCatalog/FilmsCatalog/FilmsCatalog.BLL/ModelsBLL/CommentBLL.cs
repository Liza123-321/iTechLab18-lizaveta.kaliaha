using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.BLL.ModelsBLL
{
   public class CommentBLL
    {
        public string CommentMessage { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string Data { get; set; }
    }
}

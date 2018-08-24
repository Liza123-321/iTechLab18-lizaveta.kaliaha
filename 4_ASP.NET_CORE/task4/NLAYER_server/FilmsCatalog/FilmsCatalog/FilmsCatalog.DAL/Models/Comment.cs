using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentMessage { get; set; }
        public Film Film { get; set; }
        public int FilmId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Data { get; set; }
    }
}

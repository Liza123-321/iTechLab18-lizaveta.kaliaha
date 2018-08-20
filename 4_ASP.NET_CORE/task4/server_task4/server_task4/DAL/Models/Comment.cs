using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentMessage { get; set; }
        public Film Film { get; set; }
        public int FilmId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}

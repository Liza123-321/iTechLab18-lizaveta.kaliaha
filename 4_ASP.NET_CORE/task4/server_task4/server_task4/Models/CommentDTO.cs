using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Models
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string CommentMessage { get; set; }
        public int UserId { get; set; }
    }
}

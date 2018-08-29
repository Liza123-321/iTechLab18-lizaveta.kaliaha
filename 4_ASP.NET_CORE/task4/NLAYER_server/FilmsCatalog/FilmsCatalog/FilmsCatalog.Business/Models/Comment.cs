
namespace FilmsCatalog.Business.Models
{
   public class Comment
    {
        public string CommentMessage { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string Data { get; set; }
    }
}

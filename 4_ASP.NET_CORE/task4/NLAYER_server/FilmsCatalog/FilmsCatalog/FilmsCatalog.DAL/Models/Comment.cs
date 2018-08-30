
namespace FilmsCatalog.DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentMessage { get; set; }
        public virtual Film Film { get; set; }
        public int FilmId { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public string Data { get; set; }
    }
}

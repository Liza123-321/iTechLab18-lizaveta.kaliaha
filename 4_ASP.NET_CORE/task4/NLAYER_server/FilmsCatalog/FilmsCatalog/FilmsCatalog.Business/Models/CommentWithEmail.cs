
namespace FilmsCatalog.Business.Models
{
    public class CommentWithEmail
    {
        public string CommentMessage { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string Data { get; set; }
        public string Email { get; set; }
    }
}

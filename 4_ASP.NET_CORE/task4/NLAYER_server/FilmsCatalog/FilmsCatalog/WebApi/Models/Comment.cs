using System.ComponentModel.DataAnnotations;

namespace FilmsCtalog.WebApi.Models
{
    public class Comment
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

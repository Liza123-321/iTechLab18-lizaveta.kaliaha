using System.ComponentModel.DataAnnotations;

namespace FilmsCtalog.WebApi.Models
{
    public class CommentWithEmailViewModel
    {
        public string CommentMessage { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int FilmId { get; set; }
        public string Data { get; set; }
        public string Email { get; set; }
    }
}

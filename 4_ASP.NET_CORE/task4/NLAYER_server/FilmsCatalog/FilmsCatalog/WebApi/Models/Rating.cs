using System.ComponentModel.DataAnnotations;


namespace FilmsCtalog.WebApi.Models
{
    public class Rating
    {
        [Required]
        public int Mark { get; set; }
        [Required]
        public int FilmId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;


namespace FilmsCtalog.WebApi.Models
{
    public class RatingViewModel
    {
        [Required]
        public int Mark { get; set; }
        [Required]
        public int FilmId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}

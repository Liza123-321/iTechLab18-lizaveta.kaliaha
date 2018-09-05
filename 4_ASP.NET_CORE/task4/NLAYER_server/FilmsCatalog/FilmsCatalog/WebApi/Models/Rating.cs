using System.ComponentModel.DataAnnotations;


namespace FilmsCtalog.WebApi.Models
{
    public class Rating
    {
        public int Mark { get; set; }
        public int FilmId { get; set; }
        public int UserId { get; set; }
    }
}

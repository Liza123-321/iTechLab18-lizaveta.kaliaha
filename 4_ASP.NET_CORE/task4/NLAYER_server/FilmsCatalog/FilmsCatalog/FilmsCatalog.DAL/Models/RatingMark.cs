
namespace FilmsCatalog.DAL.Models
{
    public class RatingMark
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public int FilmId { get; set; }
        public int UserId { get; set; }
        public virtual Film Film { get; set; }
        public virtual User User { get; set; }
    }
}

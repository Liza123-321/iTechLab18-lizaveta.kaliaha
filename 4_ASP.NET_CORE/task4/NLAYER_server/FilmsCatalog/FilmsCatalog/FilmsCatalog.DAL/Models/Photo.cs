

namespace FilmsCatalog.DAL.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public virtual Film Film { get; set; }
        public int FilmId { get; set; }
    }
}

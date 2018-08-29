using AutoMapper;
using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Models;
using System.Linq;

namespace FilmsCatalog.Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<DAL.Models.Comment, Models.Comment>();
            CreateMap<Models.Comment,DAL.Models.Comment>();
            CreateMap<Rating, RatingMark>();
            CreateMap<RatingMark, Rating>();
            CreateMap<DAL.Models.Comment, CommentWithEmail>().ForMember(u => u.Email, u => u.MapFrom(y => y.User.Email));
            CreateMap<DAL.Models.Film, FilmWithGenres>().ForMember(dto => dto.Genres, opt => opt.MapFrom(y => y.FilmGenres.Select(z => z.Genre).ToList()));
            CreateMap<FilmGenre, DAL.Models.Genre>();
            CreateMap<DAL.Models.Genre, GenreWithFilm>().ForMember(dto => dto.Films, opt => opt.MapFrom(y => y.FilmGenres.Select(z => z.Film).ToList()));
            CreateMap<FilmGenre, DAL.Models.Film>();
        }
  
    }
}
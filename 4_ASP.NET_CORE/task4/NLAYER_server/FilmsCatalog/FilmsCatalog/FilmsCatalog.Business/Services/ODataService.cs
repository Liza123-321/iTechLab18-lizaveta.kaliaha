using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmsCatalog.Business.Services
{
    public class ODataService : IODataService
    {
        private readonly IMapper _mapper;
        private readonly IPhotoRepository _photoRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGenreRepository _genreRepository;

        public ODataService(IMapper mapper, IPhotoRepository photoRepository, ICommentRepository commentRepository, IFilmRepository filmRepository, IRatingRepository ratingRepository, IUserRepository userRepository, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _photoRepository = photoRepository;
            _commentRepository = commentRepository;
            _filmRepository = filmRepository;
            _ratingRepository = ratingRepository;
            _userRepository = userRepository;
            _genreRepository = genreRepository;
        }

        public IQueryable<Comment> GetQueryableComments()
        {
            return _commentRepository.GetQueryableAllComments();
        }

        public IQueryable<Film> GetQueryableFilms()
        {
            return _filmRepository.GetQueryableAllFilms();
        }

        public IQueryable<Genre> GetQueryableGenres()
        {
            return _genreRepository.GetQueryableAllGenres();
        }

        public IQueryable<Photo> GetQueryablePhotos()
        {
            return _photoRepository.GetQueryableAllPhotos();
        }

        public IQueryable<RatingMark> GetQueryableRatings()
        {
            return _ratingRepository.GetQueryableAllRatings();
        }

        public IQueryable<User> GetQueryableUsers()
        {
            return _userRepository.GetQueryableAllUsers();
        }
    }
}

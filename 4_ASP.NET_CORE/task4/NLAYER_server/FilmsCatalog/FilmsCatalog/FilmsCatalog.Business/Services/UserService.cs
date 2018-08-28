using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmsCatalog.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, ITokenService tokenService,IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<List<LoginModel>> GetAllUsers()
        {
            return  _mapper.Map<List<User>, List<LoginModel>>(await _userRepository.GetAllUsers());
        }

        public async Task<string> GetEmailById(int id)
        {
            LoginModel user = await GetUserById(id);
            if (user != null) return user.Email;
            else return null;
        }

        public async Task<int> GetIdByEmail(string email)
        {
            User user = await _userRepository.GetUserByEmail(email);
            if (user != null) return user.Id;
            else return 0;
        }

        public async Task<LoginModel> GetUserById(int id)
        {
            return _mapper.Map<User, LoginModel>(await _userRepository.GetUserById(id));
        }

        public async Task<TokenModel> LoginUser(LoginModel user)
        {
            return await _tokenService.LoginUser(user.Email, user.Password);
        }

        public async Task<LoginModel> RegisterUser(LoginModel user)
        {
            User myUser = new User { Email = user.Email, Password = user.Password, Role = "user" };
            if (!_userRepository.AnyUserWithEmail(user.Email))
            {
                await _userRepository.AddUser(myUser);
                return _mapper.Map<User, LoginModel>(myUser);
            }
            else return null;

        }
    }
}

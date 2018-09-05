using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.Business.Profiles;
using FilmsCatalog.Business.Services;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FilmsCatalog.xUnit.Business
{
   public class UserServiceTests
    {
        private Mock<IUserRepository> userRepository;
        private Mock<ITokenService> tokenService;
        private IMapper mapper;
        public UserServiceTests()
        {
            userRepository = new Mock<IUserRepository>();
            tokenService = new Mock<ITokenService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();
        }

        [Fact]
        public void GetAllUsers()
        {
            // Arrange
            userRepository.Setup(u => u.GetAllUsers()).ReturnsAsync(userList);
            var service = new UserService(userRepository.Object,tokenService.Object , mapper);

            // Act
            var result = service.GetAllUsers();

            // Assert
            var viewResult = Assert.IsType<Task<List<Login>>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(userList.Count, result.Result.Count);
        }
        [Fact]
        public void GetEmailById()
        {
            // Arrange
            int userId = 2;
            userRepository.Setup(u => u.GetUserById(userId)).ReturnsAsync(userOne);
            var service = new UserService(userRepository.Object, tokenService.Object, mapper);

            // Act
            var result = service.GetEmailById(userId);

            // Assert
            var viewResult = Assert.IsType<Task<string>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(userOne.Email, result.Result);
        }
   
        [Fact]
        public void GetIdByEmail()
        {
            // Arrange
            string userEmail = "test@mail.ru";
            userRepository.Setup(u => u.GetUserByEmail(userEmail)).ReturnsAsync(userOne);
            var service = new UserService(userRepository.Object, tokenService.Object, mapper);

            // Act
            var result = service.GetIdByEmail(userEmail);

            // Assert
            var viewResult = Assert.IsType<Task<int>>(result);
            Assert.NotEqual(0, result.Result);
            Assert.Equal(userOne.Id, result.Result);
        }
        [Fact]
        public void GetUserById()
        {
            // Arrange
            int userId = 2;
            userRepository.Setup(u => u.GetUserById(userId)).ReturnsAsync(userOne);
            var service = new UserService(userRepository.Object, tokenService.Object, mapper);

            // Act
            var result = service.GetUserById(userId);

            // Assert
            var viewResult = Assert.IsType<Task<Login>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(userOne.Email, result.Result.Email);
        }
        [Fact]
        public void LoginUser()
        {
            // Arrange
            string email = "test@mail.ru";
            string password = "12345";
            tokenService.Setup(u=>u.LoginUser(email,password)).ReturnsAsync(token);
            var service = new UserService(userRepository.Object, tokenService.Object, mapper);

            // Act
            var result = service.LoginUser(loginOne);

            // Assert
            var viewResult = Assert.IsType<Task<Token>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(email, result.Result.Email);
        }

        [Fact]
        public void RegisterUser()
        {
            // Arrange
            userRepository.Setup(u => u.AddUser(userOne)).ReturnsAsync(userOne);
            var service = new UserService(userRepository.Object, tokenService.Object, mapper);

            // Act
            var result = service.RegisterUser(loginOne);

            // Assert
            var viewResult = Assert.IsType<Task<Login>>(result);
            Assert.NotNull(result.Result);
            Assert.Equal(loginOne.Email, result.Result.Email);
        }

        private List<User> userList = new List<User>()
        {
            new User{Id = 1,
            Email = "test@mail.ru",
            Password = "12345",
            Role = "user" },
            new User{Id = 2,
            Email = "t222est@mail.ru",
            Password = "12322245",
            Role = "user" },
        };
        private User userOne = new User()
        {
            Id = 2,
            Email = "t222est@mail.ru",
            Password = "12322245",
            Role = "user"
        };
        private Login loginOne = new Login()
        {
            Email = "test@mail.ru",
            Password = "12345",
        };
        private Token token = new Token()
        {
            Email = "test@mail.ru",
            Access_token = "dsfsdf"
        };

    }
}

using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.Business.Services;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FilmsCatalog.xUnit.Business
{
    public class TokenServiceTests
    {
        private Mock<IUserRepository> userRepository;
        public TokenServiceTests()
        {
            userRepository = new Mock<IUserRepository>();
        }
        [Fact]
        public void GetIdentity()
        {
            // Arrange
            string email = "test@mail.ru";
            string password = "12345";
            userRepository.Setup(c => c.GetUserByPassAndEmail(email, password)).ReturnsAsync(userOne);
            var service = new TokenService(userRepository.Object);

            // Act
            var result = service.GetIdentity(email, password);

            // Assert
            var viewResult = Assert.IsType<Task<ClaimsIdentity>>(result);
            Assert.NotNull(result.Result);
        }
        [Fact]
        public void LoginUserReturnToken()
        {
            // Arrange
            string email = "test@mail.ru";
            string password = "12345";
    
            var service = new TokenService(userRepository.Object);

            // Act
            var result = service.LoginUser(email, password);

            // Assert
            var viewResult = Assert.IsType<Task<Token>>(result);
            Assert.Null(result.Result);
        }


        private User userOne = new User()
        {
            Id = 1,
            Email = "test@mail.ru",
            Password = "12345",
            Role = "user"
        };
        private Token token = new Token()
        {
            Email = "test@mail.ru",
            Access_token = "dsfsdf"
        };


    }
}

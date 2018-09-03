using AutoMapper;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Models;
using FilmsCatalog.Business.Profiles;
using FilmsCtalog.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FilmsCatalog.xUnit.WebApi
{
    public class UserControllerTests
    {
        private Mock<IUserService> userService;
        private  IMapper mapper;

        public UserControllerTests()
        {
            userService = new Mock<IUserService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();
        }
        [Fact]
        public async void Login()
        {
            // Arrange
            FilmsCtalog.WebApi.Models.Login user = new FilmsCtalog.WebApi.Models.Login {
                Email = "test@mail.ru",
                Password = "12345"
            };
            userService.Setup(c => c.LoginUser(newUser)).ReturnsAsync(newToken);
            var controller = new UserController(userService.Object, mapper);

            // Act
            var result = await controller.Login(user);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ActionResult<Login>>(result);
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var loginTest = okResult.Value as FilmsCtalog.WebApi.Models.Login;
            Assert.NotNull(loginTest);
            Assert.Equal(user.Email, loginTest.Email);
        }

        [Fact]
        public async void Register()
        {
            // Arrange
            FilmsCtalog.WebApi.Models.Login user = new FilmsCtalog.WebApi.Models.Login
            {
                Email = "test@mail.ru",
                Password = "12345"
            };
            userService.Setup(c => c.RegisterUser(newUser)).ReturnsAsync(newUser);
            var controller = new UserController(userService.Object, mapper);

            // Act
            var result = await controller.Register(user);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ActionResult<Login>>(result);
            var okResult = result.Result as ObjectResult;
            Assert.NotNull(okResult);
            var loginTest = okResult.Value as FilmsCtalog.WebApi.Models.Login;
            Assert.NotNull(loginTest);
            Assert.Equal(user.Email, loginTest.Email);
        }

        private Login newUser = new Login
        {
            Email="test@mail.ru",
            Password="12345"
        };

        private Token newToken = new Token
        {
            Email = "test@mail.ru",
            Access_token="test"
        };
    }
}

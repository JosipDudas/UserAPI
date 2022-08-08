using Microsoft.AspNetCore.Mvc;
using UserAPI.Controllers;
using UserAPI.Logger;
using UserAPI.Models;
using UserAPI.Services;
using UserAPI.ViewModels;
using UserAPITests.Fakes;

namespace UserAPITests
{
    public class UserControllerTest
    {
        private readonly UserController _controller;
        private readonly IUserService _service;
        private readonly ILoggerManager _logger;
        public UserControllerTest()
        {
            _service = new UserServiceFake();
            _logger = new LoggerManagerFake();
            _controller = new UserController(_service, _logger);
        }

        [Fact]
        public void GetAll_SameFirstLastNames_Returns1User()
        {
            // Act
            var okResult = _controller.SameFirstLastNames(null, null) as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<ResponseModel>>(okResult.Value);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void GetAll_SameFirstLastNames_ReturnsGeorge()
        {
            // Arrange
            var FirstName = "George";
            // Act
            var okResult = _controller.SameFirstLastNames("George", null) as OkObjectResult;
            // Assert
            Assert.IsType<List<ResponseModel>>(okResult.Value);
            Assert.Equal(FirstName, (okResult.Value as List<ResponseModel>)[0].FirstName);
        }

        [Fact]
        public void GetAll_SameFirstLastNames_ReturnsGeorgeOrwell()
        {
            // Arrange
            var FirstName = "George";
            var LastName = "Orwell";
            // Act
            var okResult = _controller.SameFirstLastNames("George", "Orwell") as OkObjectResult;
            // Assert
            Assert.IsType<List<ResponseModel>>(okResult.Value);
            Assert.Equal(FirstName, (okResult.Value as List<ResponseModel>)[0].FirstName);
            Assert.Equal(LastName, (okResult.Value as List<ResponseModel>)[0].LastName);
        }


        [Fact]
        public void GetAll_SameFirstLastNames_ReturnsNotFoundResult()
        {
            // Arrange
            var FirstName = "x";
            var LastName = "y";
            // Act
            var notFoundResult = _controller.SameFirstLastNames(FirstName, LastName);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<User>>(okResult.Value);
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void GetUserById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetUserById(15);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetUserById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var Id = 1;
            // Act
            var okResult = _controller.GetUserById(Id);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetUserById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var Id = 1;
            // Act
            var okResult = _controller.GetUserById(Id) as OkObjectResult;
            // Assert
            Assert.IsType<User>(okResult.Value);
            Assert.Equal(Id, (okResult.Value as User).Id);
        }
    }
}
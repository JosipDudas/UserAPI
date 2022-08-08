using Microsoft.AspNetCore.Mvc;
using UserAPI.Bl;
using UserAPI.Logger;
using UserAPI.Models;
using UserAPI.Services;
using UserAPI.ViewModels;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IUserService _userService;
        private readonly ILoggerManager _logger;
        public UserController(IUserService service, ILoggerManager logger)
        {
            _userService = service;
            _logger = logger;
        }

        /// <summary>
        /// get users with same first and last names 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult SameFirstLastNames(string? FirstName, string? LastName)
        {
            try
            {
                List<ResponseModel> responseModel = new BlUser(_userService).GetUsersWithSameFirstLastNames(FirstName, LastName);
                if (responseModel.Count() == 0) return NotFound();
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                List<User> users = _userService.GetUserList();
                if (users == null) return NotFound();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// get user details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                User user = _userService.GetUserDetailsById(id);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}

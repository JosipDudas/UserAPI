using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPITests.Fakes
{
    public class UserServiceFake : IUserService
    {
        private readonly List<User> _users;
        public UserServiceFake()
        {
            _users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Josip",
                    LastName = "Dudaš",
                    City = string.Empty,
                    Address = string.Empty
                },new User()
                {
                    Id = 2,
                    FirstName = "Mike",
                    LastName = "Twain",
                    City = string.Empty,
                    Address = string.Empty
                },new User()
                {
                    Id = 3,
                    FirstName = "George",
                    LastName = "Orwell",
                    City = string.Empty,
                    Address = string.Empty
                },new User()
                {
                    Id = 4,
                    FirstName = "George",
                    LastName = "Dudaš",
                    City = string.Empty,
                    Address = string.Empty
                },new User()
                {
                    Id = 5,
                    FirstName = "George",
                    LastName = "Orwell",
                    City = string.Empty,
                    Address = string.Empty
                }
            };
        }
        public User GetUserDetailsById(int Id)
        {
            return _users.FirstOrDefault(a => a.Id == Id);
        }

        public List<User> GetUserList()
        {
            return _users;
        }
    }
}

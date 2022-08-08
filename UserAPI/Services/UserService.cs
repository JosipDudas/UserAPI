using UserAPI.Models;
using UserAPI.ViewModels;

namespace UserAPI.Services
{
    public class UserService : IUserService
    {
        private UserContext _context;
        public UserService (UserContext userContext)
        {
            _context = userContext;
        }

        /// <summary>
        /// get user details by user id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public User GetUserDetailsById(int Id)
        {
            User user;
            try
            {
                user = _context.Find<User>(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        /// <summary>
        /// get list of all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUserList()
        {
            List<User> userList;
            try
            {
                userList = _context.Set<User>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userList;
        }
    }
}

using UserAPI.Models;
using UserAPI.ViewModels;

namespace UserAPI.Services
{
    public interface IUserService
    {
        /// <summary>
        /// get list of all users
        /// </summary>
        /// <returns></returns>
        List<User> GetUserList();

        /// <summary>
        /// get user details by user id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        User GetUserDetailsById(int Id);
    }
}

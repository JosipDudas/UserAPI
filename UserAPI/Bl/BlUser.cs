using UserAPI.Models;
using UserAPI.Services;
using UserAPI.ViewModels;

namespace UserAPI.Bl
{
    public class BlUser
    {
        IUserService _userService;
        public BlUser(IUserService service)
        {
            _userService = service;
        }

        internal List<ResponseModel> GetUsersWithSameFirstLastNames(string? FirstName, string? LastName)
        {
            List<User> users = _userService.GetUserList();
            List<ResponseModel> duplicate = users.AsEnumerable()
                           .GroupBy(x => new { FirstName = x.FirstName, LastName = x.LastName })
                           .Where(g => g.Count() > 1)
                           .Select(y => new ResponseModel() { FirstName = y.Key.FirstName, LastName = y.Key.LastName })
                           .ToList();

            duplicate = FilterFirstName(FirstName, duplicate);
            duplicate = FilterLastName(LastName, duplicate);

            return duplicate;
        }

        private static List<ResponseModel> FilterFirstName(string? FirstName, List<ResponseModel> duplicate)
        {
            if (!string.IsNullOrEmpty(FirstName))
            {
                duplicate = duplicate.Where(x => x.FirstName.Equals(FirstName)).ToList();
            }

            return duplicate;
        }

        private static List<ResponseModel> FilterLastName(string? LastName, List<ResponseModel> duplicate)
        {
            if (!string.IsNullOrEmpty(LastName))
            {
                duplicate = duplicate.Where(x => x.LastName.Equals(LastName)).ToList();
            }

            return duplicate;
        }
    }
}

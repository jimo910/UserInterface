using UserInterface.Models;
using System.Linq;

namespace UserInterface.Data
{
    public class LoginUser : ILogin
    {
        public User Login(string emailAddress, string password)
        {
            User user = null;

            using (var dbContext = new UserInterfaceDbContext())
            {
                user = dbContext.Users.FirstOrDefault(u => u.EmailAddress.Trim().ToLower() == emailAddress.Trim().ToLower() && u.Password.Equals(password));
            }
            return user;
        }
    }
}
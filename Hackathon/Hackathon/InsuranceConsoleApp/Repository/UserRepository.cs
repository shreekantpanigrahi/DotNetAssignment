
using InsuranceConsoleApp.Model;

namespace InsuranceConsoleApp.Repository
{
    public class UserRepository
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();

        public void Register(User user)
        {
            if (users.ContainsKey(user.Username))
                throw new ArgumentException("Username already exists.");

            users.Add(user.Username, user);
        }

        public bool Login(string username, string password)
        {
            if (users.ContainsKey(username))
            {
                var user = users[username];
                return user.Password == password; // Simple password check (not secure for production).
            }
            return false;
        }
    }
}
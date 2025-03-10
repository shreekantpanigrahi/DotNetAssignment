namespace InsuranceConsoleApp.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Username and password cannot be null or empty.");

            Username = username;
            Password = password; 
        }

        public override string ToString()
        {
            return $"Username: {Username}";
        }
    }
}


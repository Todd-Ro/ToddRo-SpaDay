namespace SpaDay.Models
{
    public class User
    {
        internal string Username { get; }
        string Email;
        internal string Password { get; }

        public User() 
        { 
            Username = "Default user";
            Password = "password";
        }
        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public User(string username): this()
        {
            Username = username;
        }
    }
}

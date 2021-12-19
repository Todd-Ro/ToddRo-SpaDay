using System;

namespace SpaDay.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        internal DateTime TimeJoined { get; }

        public User() 
        { 
            //Username = "Default user";
            //Password = "password";
            TimeJoined = DateTime.Now;
        }

        public User(string username) : this()
        {
            Username = username;
        }

        public User(string username, string email, string password): this(username)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return Username;
        }


    }
}

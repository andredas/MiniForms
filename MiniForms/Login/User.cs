using MiniForms.Interfaces;

namespace MiniForms.Login
{
    class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}

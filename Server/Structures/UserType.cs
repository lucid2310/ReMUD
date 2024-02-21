using ReMUD.Module.Constants;
using System.Net.Sockets;
using System.Text;

namespace ReMUD.Module.Structures
{
    public class UserType
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public UserType(string username, string password, int id)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public string GetUsername()
        {
            return Username;
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}

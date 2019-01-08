using ReMUD.Module.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReMUD.Module.Managers
{
    public static class UserManager
    {
        public static Dictionary<int, UserType> Users = new Dictionary<int, UserType>();
        public const int INVALID_USER = -1;

        public static void LoadUsers()
        {

            Users.Add(1, new UserType("sysop", "sysop23", 1));
        }

        public static UserType GetUser(int id)
        {
            return Users[id];
        }

        public static bool UserPassword(string username, string password)
        {
            int userId = GetUserId(username);

            if(userId != INVALID_USER)
            {
                UserType userType = Users[userId];

                if(userType.GetPassword() == password)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool UserExists(string username)
        {
            foreach (var user in Users)
            {
                if (user.Value.Username == username)
                {
                    return true;
                }
            }

            return false;
        }

        public static int GetUserId(string username)
        {
            foreach (var user in Users)
            {
                if (user.Value.Username == username)
                {
                    return user.Value.Id;
                }
            }

            return INVALID_USER;
        }

        public static bool UserIdExists(int id)
        {
            return Users.ContainsKey(id);
        }

        public static string GetUsername(int id)
        {
            foreach (var user in Users)
            {
                if (user.Value.Id == id)
                {
                    return user.Value.Username;
                }
            }

            return string.Empty;
        }
    }
}

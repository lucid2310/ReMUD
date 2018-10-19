using ReMUD.Game.Structures;
using System;
using System.Collections.Generic;

namespace ReMUD.Game.Managers
{
    public class UserManager
    {
        public Dictionary<int, UserType> Users = new Dictionary<int, UserType>();
        public const int INVALID_USER = -1;

        public void LoadUsers()
        {
            LogManager.Log("Loading Users.");
            Users.Add(1, new UserType(1, "Sysop"));
        }

        public UserType GetUser(int id)
        {
            return Users[id];
        }

        public int GetUserId(string username)
        {
            foreach (var user in Users)
            {
                if(user.Value.Username == username)
                {
                    return user.Value.Id;
                }
            }

            return INVALID_USER;
        }

        public bool UserIdExists(int id)
        {
            return Users.ContainsKey(id);
        }

        public string GetUsername(int id)
        {
            foreach(var user in Users)
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

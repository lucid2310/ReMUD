using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures
{
    public struct UserType
    {
        public int Id;
        public string Username;

        public UserType(int id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}

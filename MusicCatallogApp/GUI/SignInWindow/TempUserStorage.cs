using MusicCatallogApp.Layers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.GUI.SignInWindow
{
    public static class TempUserStorage
    {
        private static Dictionary<string, User> tempUsers = new Dictionary<string, User>();

        public static void AddUser(string code, User user)
        {
            tempUsers[code] = user;
        }

        public static User GetUser(string code)
        {
            if (tempUsers.ContainsKey(code))
            {
                var user = tempUsers[code];
                tempUsers.Remove(code);
                return user;
            }
            return null;
        }
    }

}

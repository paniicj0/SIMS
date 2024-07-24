using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using MusicCatallogApp.Layers.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Controller
{
    internal class UserController
    {

        private UserService userService;

        private UserController()
        {
            userService = UserService.GetInstance();
        }

        public User GetById(int id)
        {
            return userService.GetById(id);
        }

        public List<User> GetAll()
        {
            return userService.GetAll();
        }

        public User Add(User user)
        {
            return userService.Add(user);
        }

        public void Update(User user)
        {
            userService.Update(user);
        }

        public void Delete(int id)
        {
            userService.Delete(id);
        }

        public List<User> LoadFromFile()
        {

            return userService.LoadFromFile();

        }
    }
}

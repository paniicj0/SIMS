using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Service
{
    internal class UserService
    {
        private static UserService instance=null;
        private UserRepository userRepository;

        private UserService()
        {
            userRepository=UserRepository.getInstance();
        }

        public static UserService GetInstance()
        {
            if(instance == null)
            {
                instance = new UserService();
            }
            return instance;
        }

        public User GetById(int id)
        {
            return userRepository.getById(id);
        }

        public List<User> GetAll()
        {
            return userRepository.getAll();
        }

        public User Add(User user)
        {
            return userRepository.add(user);
        }

        public void Update(User user)
        {
            userRepository.update(user);
        }

        public void Delete(int id)
        {
            userRepository.delete(id);
        }

        public List<User> LoadFromFile()
        {

            return userRepository.loadFromFile();

        }
    }
}

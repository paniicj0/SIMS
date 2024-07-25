using Microsoft.Win32;
using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.ModelEnum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicCatallogApp.Layers.Repository
{
    internal class UserRepository
    {
        private static UserRepository instance = null;
        private List<User> users;
        private readonly string filePath = "../../../Layers/Data/users.json";

        private UserRepository()
        {
            users = new List<User>();
            users = loadFromFile();
        }

        public static UserRepository getInstance()
        {
            if (instance == null)
            {
                instance = new UserRepository();
            }
            return instance;
        }

        public List<User> getAll()
        {
            return new List<User>(users);
        }

        public User getById(int id)
        {
            foreach (User user in users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public int generateId()
        {
            int maxId = 0;
            foreach (User user in users)
            {
                if (user.Id > maxId)
                {
                    maxId = user.Id;
                }
            }
            return maxId + 1;
        }

        public User add(User user)
        {
            user.Id = generateId();
            users.Add(user);
            save();
            return user;
        }

        public void delete(int id)
        {
            User user = getById(id);
            if (user == null)
            {
                return;
            }
            users.Remove(user);
            save();
        }

        public void update(User user)
        {
            User oldUser = getById(user.Id);
            if (oldUser != null)
            {
                oldUser.Name = user.Name;
                oldUser.Surname = user.Surname;
                oldUser.Email = user.Email;
                oldUser.Password = user.Password;
                oldUser.Favourites = user.Favourites;
                oldUser.ShowReviews = user.ShowReviews;
                oldUser.ShowConcact = user.ShowConcact;
                oldUser.Blocked = user.Blocked;
                oldUser.UserType = user.UserType;
                save(); // Save changes after updating
            }
        }

        public void save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath, false))
                {
                    foreach (User user in users)
                    {
                        string json = JsonConvert.SerializeObject(user, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto
                        });
                        file.WriteLine(json);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public List<User> loadFromFile()
        {
            List<User> loadedUsers = new List<User>();

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader file = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            User user = JsonConvert.DeserializeObject<User>(line, new JsonSerializerSettings
                            {
                                TypeNameHandling = TypeNameHandling.Auto
                            });
                            loadedUsers.Add(user);
                        }
                    }
                }
                users = loadedUsers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return loadedUsers;
        }
    }
}

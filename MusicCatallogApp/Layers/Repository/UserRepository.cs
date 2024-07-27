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
                save(); 
            }
        }

        public void save()
        {
            try
            {
                string json = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });

                File.WriteAllText(filePath, json);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        public List<User> loadFromFile()
        {
            List<User> loadedUsers = new List<User>();

            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    loadedUsers = JsonConvert.DeserializeObject<List<User>>(json, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto
                        });
                    
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }

            return loadedUsers;
        }

    }
}

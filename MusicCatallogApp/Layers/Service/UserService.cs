using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Data;
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

        public User logIn(String email, String password) { 
            foreach(User user in userRepository.getAll())
            {
                if(user.Email.Equals(email) && user.Password.Equals(password))
                {
                    return user;
                }
            }
            return null;
        }

        public string GetFilterExpression(DataTable dt, string[] searchTerms)
        {
            List<string> filters = new List<string>();

            foreach (string term in searchTerms)
            {
                string termFilter = string.Join(" OR ", dt.Columns.Cast<DataColumn>()
                                                    .Select(c => $"CONVERT([{c.ColumnName}], 'System.String') LIKE '%{term}%'"));
                filters.Add(termFilter);
            }

            string combinedFilter = string.Join(" AND ", filters);

            return combinedFilter;
        }
    }
}

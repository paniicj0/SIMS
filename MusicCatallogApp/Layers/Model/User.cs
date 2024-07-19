using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Model
{
    class User
    {
        private int id;
        private string name;
        private string surname;
        private string email;
        private string password;
        private List<string> favourites;
        private bool showReviews;
        private bool showConcact;
        private bool blocked;

        public User(int id,string name, string surname, string email, string password, List<string> favourites, bool showReviews, bool showConcact, bool blocked)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
            this.favourites = favourites;
            this.showReviews = showReviews;
            this.showConcact = showConcact;
            this.blocked = blocked;
        }

        public int getId() { return id; }   
        public string Name { get { return name; } }
        public string Surname { get {   return surname; } }
        public string Email { get { return email; } }
        public string Password { get { return password; } }   
        public List<string> Favourites { get { return favourites; } }
        public bool ShowReviews { get { return showReviews; } } 
        public bool ShowConcact { get { return showConcact; } }
        public bool Blocked { get { return blocked; } }

        public string StringToJson()
        {
            var userObject = new
            {
                id = this.id,
                name = this.name,
                surname = this.surname,
                email = this.email,
                password = this.password,
                favourites = this.favourites,
                showReviews = this.showReviews,
                showConcact = this.showConcact,
                blocked = this.blocked
            };

            return JsonConvert.SerializeObject(userObject, Formatting.Indented);
        }
    }
}

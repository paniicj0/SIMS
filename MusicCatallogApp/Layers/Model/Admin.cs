using MusicCatallogApp.Layers.ModelEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Model
{
    class Admin: User
    {
        public Admin(int id, string name, string surname, string email, string password, List<string> favourites, bool showReviews, bool showConcact, bool blocked,UserTypeEnum userType)
            : base(id,name, surname, email, password, favourites, showReviews, showConcact, blocked,userType)
        {}
    }
}

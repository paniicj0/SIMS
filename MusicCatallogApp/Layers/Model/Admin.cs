using MusicCatallogApp.Layers.ModelEnum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Model
{
    class Admin: User
    {
        public Admin(int id, string name, string surname, string email, string password, List<object> favourites, bool showReviews, bool showConcact, bool blocked,UserTypeEnum.UserType userType,List<int> reviewId)
            : base(id,name, surname, email, password, favourites, showReviews, showConcact, blocked,userType,reviewId)
        {}

        public override string StringToJson()
        {
            var adminObject = new
            {
                Id,
                Name,
                Surname,
                Email,
                Password,
                Favourites,
                ShowReviews,
                ShowConcact,
                Blocked,
                UserType,
                ReviewId
            };
            return JsonConvert.SerializeObject(adminObject, Formatting.Indented);
        }
    }
}

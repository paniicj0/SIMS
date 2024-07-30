using MusicCatallogApp.Layers.ModelEnum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MusicCatallogApp.Layers.Model
{
    public class MusicEditors:User
    {
        private int numOfInputContent;
        private List<string> tasksList;

        public MusicEditors(int id,string name, string surname, string email, string password, List<object> favourites, bool showReviews, bool showConcact, bool blocked,UserTypeEnum.UserType userType,List<int> reviewId, int numOfInputContent, List<string> tasksList)
            : base(id,name, surname, email, password, favourites, showReviews, showConcact, blocked,userType,reviewId)
        {
            this.numOfInputContent = numOfInputContent;
            this.tasksList = tasksList;
        }

        public int NumOfInputContent
        {
            get { return numOfInputContent; }
            set { numOfInputContent = value; }
        }

        public List<string> TasksList
        {
            get { return tasksList; }
            set { tasksList = value; }
        }

        public new string StringToJson()
        {
            string baseJson = base.StringToJson();

            var baseObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(baseJson);

            baseObject["numOfInputContent"] = this.numOfInputContent;
            baseObject["tasksList"] = this.tasksList;

            return JsonConvert.SerializeObject(baseObject, Formatting.Indented);
        }

    }
}

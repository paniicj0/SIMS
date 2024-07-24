﻿using MusicCatallogApp.Layers.ModelEnum;
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
    class MusicEditors:User
    {
        private int numOfInputContent;
        private List<string> tasksList;

        public MusicEditors(int id,string name, string surname, string email, string password, List<string> favourites, bool showReviews, bool showConcact, bool blocked,UserTypeEnum.UserType userType, int numOfInputContent, List<string> tasksList)
            : base(id,name, surname, email, password, favourites, showReviews, showConcact, blocked,userType)
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
            // Pozivanje StringToJson metode iz bazne klase
            string baseJson = base.StringToJson();

            // Parsiranje baznog JSON stringa u objekt
            var baseObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(baseJson);

            // Dodavanje dodatnih svojstava iz MusicEditors klase
            baseObject["numOfInputContent"] = this.numOfInputContent;
            baseObject["tasksList"] = this.tasksList;

            // Serijalizacija konačnog objekta natrag u JSON string
            return JsonConvert.SerializeObject(baseObject, Formatting.Indented);
        }

    }
}

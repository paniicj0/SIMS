using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Model
{
    class Application
    {
        private int id;
        private int numOfAccesses;
        private int numOfViews;

        public Application(int id,int numOfAccesses, int numOfViews)
        {
            this.id = id;
            this.numOfAccesses = numOfAccesses;
            this.numOfViews = numOfViews;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int NumOfAccesses { 
            get { return numOfAccesses; }
            set { numOfAccesses = value; }
        }
        public int NumOfViews { 
            get { return numOfViews; }
            set { numOfViews = value; }
        }

        public string StringToJson()
        {
            var appObject = new
            {
                id = this.id,
                numOfAccesses = this.numOfAccesses,
                numOfViews = this.numOfViews
            };

            return JsonConvert.SerializeObject(appObject, Formatting.Indented);

        }
    }
}

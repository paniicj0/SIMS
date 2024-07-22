using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Model
{
    class App
    {
        private int id;
        private int numOfAccesses;
        private int numOfViews;

        public App(int id,int numOfAccesses, int numOfViews)
        {
            this.id = id;
            this.numOfAccesses = numOfAccesses;
            this.numOfViews = numOfViews;
        }

        public int getId() { return id; }
        public int NumOfAccesses { get; set; }
        public int NumOfViews { get; set; }

        public String StringToJson()
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

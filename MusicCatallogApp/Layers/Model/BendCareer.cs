using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Model
{
    class BendCareer
    {
        private int id;
        private List<string> links;
        private List<string> participants;
        private string picture;
        private string biography;
        private string bendRelease;//izdanje benda, menja se ako nastane neko novo u medjuvremenu
        private List<string> concerts;
        public BendCareer(int id,List<string> links, List<string> participants, string picture, string biography, string bendRelease, List<string> concerts)
        {
            this.id = id;
            this.links = links;
            this.participants = participants;
            this.picture = picture;
            this.biography = biography;
            this.bendRelease = bendRelease;
            this.concerts = concerts;
        }

        public int Id {
            get {  return id; }
            set { id = value; }
        }
        public List<string> Links { 
            get { return links; }
            set { links = value; }
        }
        public List<string> Participants {
            get { return participants; }
            set{participants = value; }
        }
        public string Picture { 
            get { return picture; }
            set { picture = value; }
        }
        public string Biography { 
            get { return biography; }
            set { biography = value; }
        }
        public string BendRelease
        {
            get { return bendRelease; }
            set { bendRelease = value; }
        }
        public List<string> Concerts { 
            get { return concerts; }
            set { concerts = value; }
        }

        public String StringToJson()
        {
            var bendObject = new
            {
                id = this.id,
                links = this.links,
                participants = this.participants,
                picture = this.picture,
                biography = this.biography,
                bendRelase = this.bendRelease,
                concerts = this.concerts

            };

            return JsonConvert.SerializeObject(bendObject,Formatting.Indented);
        }

    }
}

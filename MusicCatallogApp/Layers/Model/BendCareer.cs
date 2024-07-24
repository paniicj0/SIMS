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
        private string bendRelase;
        private string concert;
        public BendCareer(int id,List<string> links, List<string> participants, string picture, string biography, string bendRelease, string concert)
        {
            this.id = id;
            this.links = links;
            this.participants = participants;
            this.picture = picture;
            this.biography = biography;
            this.biography = bendRelease;
            this.concert = concert;
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
            get { return bendRelase; }
            set { bendRelase = value; }
        }
        public string Concert { 
            get { return concert; }
            set { concert = value; }
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
                bendRelase = this.bendRelase,
                concert = this.concert

            };

            return JsonConvert.SerializeObject(bendObject,Formatting.Indented);
        }

    }
}

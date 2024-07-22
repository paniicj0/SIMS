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

        public int Id { get; set; }
        public List<string> Links { get; set; }
        public List<string> Participants { get; set; }
        public string Picture { get; set; }
        public string Biography { get; set; }
        public string BendRelease { get; set; }
        public string Concert { get; set; }

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

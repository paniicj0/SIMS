using MusicCatallogApp.Layers.ModelEnum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Model
{
    class Preformer
    {
        private int id;
        private string biography;
        private string picture;
        private PreformerTypeEnum.PreformerType type;
        private bool soloCareer;
        private bool bendCareer;

        public Preformer(int id,string biography, string picture, PreformerTypeEnum.PreformerType type, bool soloCareer, bool bendCareer)
        {
            this.id = id;
            this.biography = biography;
            this.picture = picture;
            this.type = type;
            this.soloCareer = soloCareer;
            this.bendCareer = bendCareer;
        }

        public int getId() { return id; }
        public string Biography {  get { return biography; } }
        public string Picture { get { return picture; } }
        public PreformerTypeEnum.PreformerType Type { get { return type; } }
        public bool SoloCarrer {  get { return soloCareer; } }
        public bool BendCareer { get { return bendCareer; } }

        public string StringToJson()
        {
            var preformerObject = new
            {
                id = this.id,
                biography = this.biography,
                picture = this.picture,
                type = this.type,
                soloCareer = this.soloCareer,
                bendCareer = this.bendCareer

            };

            return JsonConvert.SerializeObject(preformerObject, Formatting.Indented);
        }
    }
}

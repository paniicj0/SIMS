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

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Biography {  get { return biography; } set { biography = value; } }
        public string Picture { get { return picture; } set { picture = value; } }
        public PreformerTypeEnum.PreformerType Type { get { return type; } set { type = value; } }
        public bool SoloCarrer {  get { return soloCareer; } set { soloCareer = value; } }
        public bool BendCareer { get { return bendCareer; } set { bendCareer = value; } }

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

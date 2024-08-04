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
        private string name;
        private string surname;
        private string biography;
        private string picture;
        private PreformerTypeEnum.PreformerType type;
        private bool soloCareer;
        private bool bendCareer;

        public Preformer(int id,string name,string surname,string biography, string picture, PreformerTypeEnum.PreformerType type, bool soloCareer, bool bendCareer)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
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
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public string Biography {  get { return biography; } set { biography = value; } }
        public string Picture { get { return picture; } set { picture = value; } }
        public PreformerTypeEnum.PreformerType Type { get { return type; } set { type = value; } }
        public bool SoloCareer {  get { return soloCareer; } set { soloCareer = value; } }
        public bool BendCareer { get { return bendCareer; } set { bendCareer = value; } }

        public string StringToJson()
        {
            var preformerObject = new
            {
                id = this.id,
                name = this.name,
                surname = this.surname,
                biography = this.biography,
                picture = this.picture,
                type = this.type,
                soloCareer = this.soloCareer,
                bendCareer = this.bendCareer

            };

            return JsonConvert.SerializeObject(preformerObject, Formatting.Indented);
        }

        public string DisplayInfo => $"{Name} {Surname} {Type} ({(SoloCareer ? "Solo" : "Band")})";

        public override string ToString()
        {
            return $"{Name} {Surname} ({Type})";
        }
    }
}

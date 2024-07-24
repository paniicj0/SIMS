using MusicCatallogApp.Layers.ModelEnum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Model
{
    class Album
    {
        private int id;
        private string name;
        private AlbumTypeEnum.AlubmType albumType;

        public Album(int id, string name, AlbumTypeEnum.AlubmType albumType)
        {
            this.id = id;
            this.name = name;
            this.albumType = albumType;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public AlbumTypeEnum.AlubmType AlbumType
        {

            get { return albumType; }
            set { albumType = value; }
        }
        public string StringToJson()
        {
            var albumObject = new
            {
                id = this.id,
                name = this.name,
                albumType = this.albumType

            };


            return JsonConvert.SerializeObject(albumObject, Formatting.Indented);
        }
    }
}

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
        private AlbumTypeEnum albumType;

        public Album(int id, string name, AlbumTypeEnum albumType)
        {
            this.id = id;
            this.name = name;
            this.albumType = albumType;
        }

        public int getId() { return id; }
        public string getName() { return name; }
        public AlbumTypeEnum getAlbumType() { return albumType; }

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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Model
{
    class MusicalPiece
    {
        private int id;
        private string text;
        private string picture;
        private DateOnly creationDate;
        private List<Preformer> participants;
        public MusicalPiece(int id,string text, string picture, DateOnly creationDate, List<Preformer> participants)
        {
            this.id = id;
            this.text = text;
            this.picture = picture;
            this.creationDate = creationDate;
            this.participants = participants;
        }

        public string Text { get; set; }
        public string Picture { get; set; }
        public DateOnly CreationDate { get; set; }
        public List<Preformer> Participants { get; set; }

        public string StringToJson()
        {
            var pieceObject = new
            {
                id = this.id,
                text = this.text,
                picture = this.picture,
                creationDate = this.creationDate,
                participants = this.participants
            };

            return JsonConvert.SerializeObject(pieceObject,Formatting.Indented);
        }

    }
}

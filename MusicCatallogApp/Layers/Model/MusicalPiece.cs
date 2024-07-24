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

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Text { 
            get { return text; } set { text = value; }
        }
        public string Picture { 
            get { return picture; } set {   picture = value; }
        }
        public DateOnly CreationDate { 
            get { return creationDate; } set { creationDate = value; }
        }
        public List<Preformer> Participants { 
            get { return participants; } set { participants = value; }
        }

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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Model
{
    class ReviewMapping
    {

        private int id;
        private int itemId;
        private List<int> reviewsIds;

        public ReviewMapping(int id, int itemId, List<int> reviewsIds)
        {
            this.id = id;
            this.itemId = itemId;
            this.reviewsIds = reviewsIds;
           
        }
        public int Id {
            get { return id; }
            set {  id = value; }
        }
        public int ItemId { 
            get { return itemId; }
            set { itemId = value; }
        }
        public List<int> ReviewIds {

            get { return reviewsIds; }
            set {  reviewsIds = value; } 
        }

        public string StringToJson()
        {
            var rObject= new
            {
                id = this.id,
                itemId = this.itemId,
                reviewsIds = this.reviewsIds
            };

            return JsonConvert.SerializeObject(rObject,Formatting.Indented);

        }
    }
}

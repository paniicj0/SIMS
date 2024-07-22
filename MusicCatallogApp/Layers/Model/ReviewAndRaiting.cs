using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Model
{
    class ReviewAndRaiting
    {
        private int id;
        private string review;
        private int grade;
        private int numOfStars;
        private ReviewAndRaiting reviewType;
        private bool approved;

        public ReviewAndRaiting(int id,string review, int grade, int numOfStars, ReviewAndRaiting reviewType, bool approved)
        {
            this.id = id;
            this.review = review;
            this.grade = grade;
            this.numOfStars = numOfStars;
            this.reviewType = reviewType;
            this.approved = approved;
        }

        public int getId() { return id; }
        public string Review { get { return review; } }
        public int Grade { get { return grade; } }
        public bool Approved { get { return approved; } }
        public int NumOfStars {  get { return numOfStars; } }
        public ReviewAndRaiting ReviewType { get { return reviewType; } }

        public string StringToJson()
        {
            var reviewObject = new
            {
                id = this.id,
                review = this.review,
                grade = this.grade,
                numOfStars = this.numOfStars,
                reviewType = this.reviewType,
                approved = this.approved
            };

            return JsonConvert.SerializeObject(reviewObject, Formatting.Indented);
        }

    }
}

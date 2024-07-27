using MusicCatallogApp.Layers.ModelEnum;
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
        public int id;
        public string review;
        public int grade;
        public int numOfStars;
        public ReviewTypeEnum.ReviewType reviewType;
        public bool approved;

        public ReviewAndRaiting(int id,string review, int grade, int numOfStars, ReviewTypeEnum.ReviewType reviewType, bool approved)
        {
            this.id = id;
            this.review = review;
            this.grade = grade;
            this.numOfStars = numOfStars;
            this.reviewType = reviewType;
            this.approved = approved;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Review { get { return review; }  set { review = value; } }
        public int Grade { get { return grade; } set { grade = value; } }
        public bool Approved { get { return approved; } set { approved = value; } }
        public int NumOfStars {  get { return numOfStars; } set { numOfStars = value; } }
        public ReviewTypeEnum.ReviewType ReviewType { get { return reviewType; } set { reviewType = value; } }

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

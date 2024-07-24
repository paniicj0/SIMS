using MusicCatallogApp.Layers.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicCatallogApp.Layers.Repository
{
    internal class ReviewAndRaitingRepository
    {
        private static ReviewAndRaitingRepository instance = null;
        private List<ReviewAndRaiting> reviewsAndRatings;
        private readonly string filePath = "../../../Layers/Data/reviewsAndRating.json";

        private ReviewAndRaitingRepository()
        {
            reviewsAndRatings = new List<ReviewAndRaiting>();
        }

        public static ReviewAndRaitingRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ReviewAndRaitingRepository();
            }
            return instance;
        }

        public List<ReviewAndRaiting> getAll()
        {
            return new List<ReviewAndRaiting>(reviewsAndRatings);
        }

        public ReviewAndRaiting getById(int id)
        {
            foreach (ReviewAndRaiting reviewAndRating in reviewsAndRatings)
            {
                if (reviewAndRating.Id == id)
                {
                    return reviewAndRating;
                }
            }
            return null;
        }

        public int generateId()
        {
            int maxId = 0;
            foreach (ReviewAndRaiting reviewAndRating in reviewsAndRatings)
            {
                if (reviewAndRating.Id > maxId)
                {
                    maxId = reviewAndRating.Id;
                }
            }
            return maxId + 1;
        }

        public ReviewAndRaiting add(ReviewAndRaiting reviewAndRating)
        {
            reviewAndRating.Id = generateId();
            reviewsAndRatings.Add(reviewAndRating);
            save();
            return reviewAndRating;
        }

        public void delete(int id)
        {
            ReviewAndRaiting reviewAndRating = getById(id);
            if (reviewAndRating == null)
            {
                return;
            }
            reviewsAndRatings.Remove(reviewAndRating);
            save();
        }

        public void update(ReviewAndRaiting reviewAndRating)
        {
            ReviewAndRaiting oldReviewAndRating = getById(reviewAndRating.Id);
            if (oldReviewAndRating != null)
            {
                oldReviewAndRating.Review = reviewAndRating.Review;
                oldReviewAndRating.Grade = reviewAndRating.Grade;
                oldReviewAndRating.NumOfStars = reviewAndRating.NumOfStars;
                oldReviewAndRating.ReviewType = reviewAndRating.ReviewType;
                oldReviewAndRating.Approved = reviewAndRating.Approved;
                save();
            }
        }

        public void save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    foreach (ReviewAndRaiting reviewAndRating in reviewsAndRatings)
                    {
                        file.WriteLine(reviewAndRating.StringToJson());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public List<ReviewAndRaiting> loadFromFile()
        {
            List<ReviewAndRaiting> loadedReviewsAndRatings = new List<ReviewAndRaiting>();

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader file = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            ReviewAndRaiting reviewAndRating = JsonConvert.DeserializeObject<ReviewAndRaiting>(line);
                            loadedReviewsAndRatings.Add(reviewAndRating);
                        }
                    }
                }
                reviewsAndRatings = loadedReviewsAndRatings;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return loadedReviewsAndRatings;
        }
    }
}

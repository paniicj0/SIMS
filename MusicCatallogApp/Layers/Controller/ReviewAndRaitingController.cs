using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using MusicCatallogApp.Layers.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Controller
{
    internal class ReviewAndRaitingController
    {
        private ReviewAndRaitingService reviewService;

        public ReviewAndRaitingController()
        {
            reviewService = ReviewAndRaitingService.GetInstance();
        }

        public ReviewAndRaiting GetById(int id)
        {
            return reviewService.GetById(id);
        }

        public List<ReviewAndRaiting> GetAll()
        {
            return reviewService.GetAll();
        }

        public ReviewAndRaiting Add(ReviewAndRaiting review)
        {
            return reviewService.Add(review);
        }

        public void Update(ReviewAndRaiting review)
        {
            reviewService.Update(review);
        }

        public void Delete(int id)
        {
            reviewService.Delete(id);
        }

        public List<ReviewAndRaiting> LoadFromFile()
        {

            return reviewService.LoadFromFile();

        }
    }
}

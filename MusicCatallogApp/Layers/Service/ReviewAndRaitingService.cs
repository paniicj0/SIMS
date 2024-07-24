using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Service
{
    internal class ReviewAndRaitingService
    {
        private static ReviewAndRaitingService instance = null;
        private ReviewAndRaitingRepository reviewRepository;

        private ReviewAndRaitingService()
        {
            reviewRepository = ReviewAndRaitingRepository.getInstance();
        }

        public static ReviewAndRaitingService GetInstance()
        {
            if (instance == null)
            {
                instance = new ReviewAndRaitingService();
            }
            return instance;
        }

        public ReviewAndRaiting GetById(int id)
        {
            return reviewRepository.getById(id);
        }

        public List<ReviewAndRaiting> GetAll()
        {
            return reviewRepository.getAll();
        }

        public ReviewAndRaiting Add(ReviewAndRaiting review)
        {
            return reviewRepository.add(review);
        }

        public void Update(ReviewAndRaiting review)
        {
            reviewRepository.update(review);
        }

        public void Delete(int id)
        {
            reviewRepository.delete(id);
        }

        public List<ReviewAndRaiting> LoadFromFile()
        {

            return reviewRepository.loadFromFile();

        }
    }
}

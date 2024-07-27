using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Service
{
    class ReviewMappingService
    {
        private static ReviewMappingService instance=null;
        private ReviewMappingRepository mappingRepository;

        private ReviewMappingService()
        {
            mappingRepository=ReviewMappingRepository.getInstance();
        }

        public static ReviewMappingService GetInstance() { 
            if (instance == null)
            {
                instance = new ReviewMappingService();
            }
            return instance;
        }

        public List<ReviewMapping> getAll()
        {
            return mappingRepository.getAll();
        }

        public ReviewMapping getById(int id)
        {
            return mappingRepository.getById(id);
        }

        public ReviewMapping add(ReviewMapping map)
        {
            return mappingRepository.add(map);
        }

        public void delete(int id)
        {
            mappingRepository.delete(id);
        }

        public void update(ReviewMapping map)
        {
           mappingRepository.update(map);
        }

        public List<ReviewMapping> loadFromFile()
        {
            return mappingRepository.loadFromFile();
        }
    }
}

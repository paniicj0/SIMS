using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Controller
{
    class ReviewMappingController
    {
        private ReviewMappingService service;

        public ReviewMappingController()
        {
            service = ReviewMappingService.GetInstance();
        }

        public List<ReviewMapping> getAll()
        {
            return service.getAll();
        }

        public ReviewMapping getById(int id)
        {
            return service.getById(id);
        }

        public ReviewMapping add(ReviewMapping map)
        {
            return service.add(map);
        }

        public void delete(int id)
        {
            service.delete(id);
        }

        public void update(ReviewMapping map)
        {
            service.update(map);
        }

        public List<ReviewMapping> loadFromFile()
        {
            return service.loadFromFile();
        }
    }
}

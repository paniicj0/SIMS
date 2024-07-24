using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Service
{
    internal class ApplicationService
    {
        private static ApplicationService instance = null;
        private ApplicationRepository appRepository;

        private ApplicationService()
        {
            appRepository = ApplicationRepository.getInstance();
        }

        public static ApplicationService GetInstance()
        {
            if (instance == null)
            {
                instance = new ApplicationService();
            }
            return instance;
        }

        public Application GetById(int id)
        {
            return appRepository.getById(id);
        }

        public List<Application> GetAll()
        {
            return appRepository.getAll();
        }

        public Application Add(Application app)
        {
            return appRepository.add(app);
        }

        public void Update(Application app)
        {
            appRepository.update(app);
        }

        public void Delete(int id)
        {
            appRepository.delete(id);
        }

        public List<Application> LoadFromFile()
        {

            return appRepository.loadFromFile();

        }
    }
}

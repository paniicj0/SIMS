using MusicCatallogApp.Layers.Repository;
using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Controller
{
    internal class ApplicationController
    {
        private ApplicationService appService;

        private ApplicationController()
        {
            appService = ApplicationService.GetInstance();
        }


        public Application GetById(int id)
        {
            return appService.GetById(id);
        }

        public List<Application> GetAll()
        {
            return appService.GetAll();
        }

        public Application Add(Application app)
        {
            return appService.Add(app);
        }

        public void Update(Application app)
        {
            appService.Update(app);
        }

        public void Delete(int id)
        {
            appService.Delete(id);
        }

        public List<Application> LoadFromFile()
        {

            return appService.LoadFromFile();

        }
    }
}

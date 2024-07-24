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
    internal class MusicEditorsController
    {
        private  MusicEditorsService editorsService;

        private MusicEditorsController()
        {
            editorsService = MusicEditorsService.GetInstance();
        }


        public MusicEditors GetById(int id)
        {
            return editorsService.GetById(id);
        }

        public List<MusicEditors> GetAll()
        {
            return editorsService.GetAll();
        }

        public MusicEditors Add(MusicEditors user)
        {
            return editorsService.Add(user);
        }

        public void Update(MusicEditors user)
        {
            editorsService.Update(user);
        }

        public void Delete(int id)
        {
            editorsService.Delete(id);
        }

        public List<MusicEditors> LoadFromFile()
        {

            return editorsService.LoadFromFile();

        }
    }
}

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
    internal class BendCareerController
    {
        private BendCareerService bendSerivce;

        public BendCareerController()
        {
            bendSerivce = BendCareerService.GetInstance();
        }


        public BendCareer GetById(int id)
        {
            return bendSerivce.GetById(id);
        }

        public List<BendCareer> GetAll()
        {
            return bendSerivce.GetAll();
        }

        public BendCareer Add(BendCareer bend)
        {
            return bendSerivce.Add(bend);
        }

        public void Update(BendCareer bend)
        {
            bendSerivce.Update(bend);
        }

        public void Delete(int id)
        {
            bendSerivce.Delete(id);
        }

        public List<BendCareer> LoadFromFile()
        {

            return bendSerivce.LoadFromFile();

        }
    }
}

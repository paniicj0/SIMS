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
    internal class PreformerController
    {
        private  PreformerService preformerService;

        public PreformerController()
        {
            preformerService = PreformerService.GetInstance();
        }

        public Preformer GetById(int id)
        {
            return preformerService.GetById(id);
        }

        public List<Preformer> GetAll()
        {
            return preformerService.GetAll();
        }

        public Preformer Add(Preformer user)
        {
            return preformerService.Add(user);
        }

        public void Update(Preformer user)
        {
            preformerService.Update(user);
        }

        public void Delete(int id)
        {
            preformerService.Delete(id);
        }

        public List<Preformer> LoadFromFile()
        {

            return preformerService.LoadFromFile();

        }
    }
}

using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Service
{
    internal class PreformerService
    {
        private static PreformerService instance = null;
        private PreformerRepository preformerRepository;

        private PreformerService()
        {
            preformerRepository = PreformerRepository.getInstance();
        }

        public static PreformerService GetInstance()
        {
            if (instance == null)
            {
                instance = new PreformerService();
            }
            return instance;
        }

        public Preformer GetById(int id)
        {
            return preformerRepository.getById(id);
        }

        public List<Preformer> GetAll()
        {
            return preformerRepository.getAll();
        }

        public Preformer Add(Preformer user)
        {
            return preformerRepository.add(user);
        }

        public void Update(Preformer user)
        {
            preformerRepository.update(user);
        }

        public void Delete(int id)
        {
            preformerRepository.delete(id);
        }

        public List<Preformer> LoadFromFile()
        {

            return preformerRepository.loadFromFile();

        }
    }
}

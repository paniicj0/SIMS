using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Service
{
    internal class BendCareerService
    {
        private static BendCareerService instance = null;
        private BendCareerRepository bendRepository;

        private BendCareerService()
        {
            bendRepository = BendCareerRepository.getInstance();
        }

        public static BendCareerService GetInstance()
        {
            if (instance == null)
            {
                instance = new BendCareerService();
            }
            return instance;
        }

        public BendCareer GetById(int id)
        {
            return bendRepository.getById(id);
        }

        public List<BendCareer> GetAll()
        {
            return bendRepository.getAll();
        }

        public BendCareer Add(BendCareer bend)
        {
            return bendRepository.add(bend);
        }

        public void Update(BendCareer bend)
        {
            bendRepository.update(bend);
        }

        public void Delete(int id)
        {
            bendRepository.delete(id);
        }

        public List<BendCareer> LoadFromFile()
        {

            return bendRepository.loadFromFile();

        }
    }
}

using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Service
{
    internal class MusicEditorsService
    {
        private static MusicEditorsService instance = null;
        private MusicEditorsRepository editorsRepository;

        private MusicEditorsService()
        {
            editorsRepository = MusicEditorsRepository.getInstance();
        }

        public static MusicEditorsService GetInstance()
        {
            if (instance == null)
            {
                instance = new MusicEditorsService();
            }
            return instance;
        }

        public MusicEditors GetById(int id)
        {
            return editorsRepository.getById(id);
        }

        public List<MusicEditors> GetAll()
        {
            return editorsRepository.getAll();
        }

        public MusicEditors Add(MusicEditors user)
        {
            return editorsRepository.add(user);
        }

        public void Update(MusicEditors user)
        {
            editorsRepository.update(user);
        }

        public void Delete(int id)
        {
            editorsRepository.delete(id);
        }

        public List<MusicEditors> LoadFromFile()
        {

            return editorsRepository.loadFromFile();

        }
    }
}

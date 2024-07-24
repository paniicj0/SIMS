using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Service
{
    internal class MusicalPieceService
    {
        private static MusicalPieceService instance = null;
        private MusicalPieceRepository pieceRepository;

        private MusicalPieceService()
        {
            pieceRepository = MusicalPieceRepository.getInstance();
        }

        public static MusicalPieceService GetInstance()
        {
            if (instance == null)
            {
                instance = new MusicalPieceService();
            }
            return instance;
        }

        public MusicalPiece GetById(int id)
        {
            return pieceRepository.getById(id);
        }

        public List<MusicalPiece> GetAll()
        {
            return pieceRepository.getAll();
        }

        public MusicalPiece Add(MusicalPiece user)
        {
            return pieceRepository.add(user);
        }

        public void Update(MusicalPiece user)
        {
            pieceRepository.update(user);
        }

        public void Delete(int id)
        {
            pieceRepository.delete(id);
        }

        public List<MusicalPiece> LoadFromFile()
        {

            return pieceRepository.loadFromFile();

        }
    }
}

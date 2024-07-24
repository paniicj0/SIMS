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
    internal class MusicalPieceController
    {
        private  MusicalPieceService pieceSerice;

        private MusicalPieceController()
        {
            pieceSerice = MusicalPieceService.GetInstance();
        }

        public MusicalPiece GetById(int id)
        {
            return pieceSerice.GetById(id);
        }

        public List<MusicalPiece> GetAll()
        {
            return pieceSerice.GetAll();
        }

        public MusicalPiece Add(MusicalPiece user)
        {
            return pieceSerice.Add(user);
        }

        public void Update(MusicalPiece user)
        {
            pieceSerice.Update(user);
        }

        public void Delete(int id)
        {
            pieceSerice.Delete(id);
        }

        public List<MusicalPiece> LoadFromFile()
        {

            return pieceSerice.LoadFromFile();

        }
    }
}

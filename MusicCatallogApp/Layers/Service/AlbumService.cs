using MusicCatallogApp.Layers.Model;
using MusicCatallogApp.Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Service
{
    internal class AlbumService
    {
        private static AlbumService instance = null;
        private AlbumRepository albumRepository;

        private AlbumService()
        {
            albumRepository = AlbumRepository.getInstance();
        }

        public static AlbumService GetInstance()
        {
            if (instance == null)
            {
                instance = new AlbumService();
            }
            return instance;
        }

        public Album GetById(int id)
        {
            return albumRepository.getById(id);
        }

        public List<Album> GetAll()
        {
            return albumRepository.getAll();
        }

        public Album Add(Album album)
        {
            return albumRepository.add(album);
        }

        public void Update(Album album)
        {
            albumRepository.update(album);
        }

        public void Delete(int id)
        {
            albumRepository.delete(id);
        }

        public List<Album> LoadFromFile()
        {

            return albumRepository.loadFromFile();

        }
    }
}

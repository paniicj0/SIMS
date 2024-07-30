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
    internal class AlbumController
    {
        private static AlbumService albumService;

        public AlbumController()
        {
            albumService = AlbumService.GetInstance();
        }

        public Album GetById(int id)
        {
            return albumService.GetById(id);
        }

        public List<Album> GetAll()
        {
            return albumService.GetAll();
        }

        public Album Add(Album album)
        {
            return albumService.Add(album);
        }

        public void Update(Album album)
        {
            albumService.Update(album);
        }

        public void Delete(int id)
        {
            albumService.Delete(id);
        }

        public List<Album> LoadFromFile()
        {

            return albumService.LoadFromFile();

        }
    }
}

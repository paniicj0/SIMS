using MusicCatallogApp.Layers.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicCatallogApp.Layers.Repository
{
    internal class AlbumRepository
    {
        private static AlbumRepository instance = null;
        private List<Album> albums;
        private readonly string filePath = "../../../Layers/Data/album.json";

        private AlbumRepository()
        {
            albums = new List<Album>();
            albums = loadFromFile();
        }

        public static AlbumRepository getInstance()
        {
            if (instance == null)
            {
                instance = new AlbumRepository();
            }
            return instance;
        }

        public List<Album> getAll()
        {
            return new List<Album>(albums);
        }

        public Album getById(int id)
        {
            foreach (Album album in albums)
            {
                if (album.Id == id)
                {
                    return album;
                }
            }
            return null;
        }

        public int generateId()
        {
            int maxId = 0;
            foreach (Album album in albums)
            {
                if (album.Id > maxId)
                {
                    maxId = album.Id;
                }
            }
            return maxId + 1;
        }

        public Album add(Album album)
        {
            album.Id = generateId();
            albums.Add(album);
            save();
            return album;
        }

        public void delete(int id)
        {
            Album album = getById(id);
            if (album == null)
            {
                return;
            }
            albums.Remove(album);
            save();
        }

        public void update(Album album)
        {
            Album oldAlbum = getById(album.Id);
            if (oldAlbum != null)
            {
                oldAlbum.Name = album.Name;
                oldAlbum.AlbumType = album.AlbumType;
            }
            save();
        }

        public void save()
        {
            try
            {
                string json = JsonConvert.SerializeObject(albums, Formatting.Indented, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });

                File.WriteAllText(filePath, json);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        public List<Album> loadFromFile()
        {
            List<Album> loadedAlbums = new List<Album>();

            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    loadedAlbums = JsonConvert.DeserializeObject<List<Album>>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    });
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }

            return loadedAlbums;
        }
    }
}

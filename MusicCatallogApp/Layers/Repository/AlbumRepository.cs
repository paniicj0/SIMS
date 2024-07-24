﻿using MusicCatallogApp.Layers.Model;
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
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    foreach (Album album in albums)
                    {
                        file.WriteLine(album.StringToJson());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public List<Album> loadFromFile()
        {
            List<Album> loadedAlbums = new List<Album>();

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader file = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            Album album = JsonConvert.DeserializeObject<Album>(line);
                            loadedAlbums.Add(album);
                        }
                    }
                }
                albums = loadedAlbums;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return loadedAlbums;
        }
    }
}

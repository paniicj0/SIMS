using MusicCatallogApp.Layers.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicCatallogApp.Layers.Repository
{
    internal class PreformerRepository
    {
        private static PreformerRepository instance = null;
        private List<Preformer> preformers;
        private readonly string filePath = "../../../Layers/Data/preformer.json";

        private PreformerRepository()
        {
            preformers = new List<Preformer>();
            preformers = loadFromFile();
        }

        public static PreformerRepository getInstance()
        {
            if (instance == null)
            {
                instance = new PreformerRepository();
            }
            return instance;
        }

        public List<Preformer> getAll()
        {
            return new List<Preformer>(preformers);
        }

        public Preformer getById(int id)
        {
            foreach (Preformer preformer in preformers)
            {
                if (preformer.Id == id)
                {
                    return preformer;
                }
            }
            return null;
        }

        public int generateId()
        {
            int maxId = 0;
            foreach (Preformer preformer in preformers)
            {
                if (preformer.Id > maxId)
                {
                    maxId = preformer.Id;
                }
            }
            return maxId + 1;
        }

        public Preformer add(Preformer preformer)
        {
            preformer.Id = generateId();
            preformers.Add(preformer);
            save();
            return preformer;
        }

        public void delete(int id)
        {
            Preformer preformer = getById(id);
            if (preformer == null)
            {
                return;
            }
            preformers.Remove(preformer);
            save();
        }

        public void update(Preformer preformer)
        {
            Preformer oldPreformer = getById(preformer.Id);
            if (oldPreformer != null)
            {
                oldPreformer.Name = preformer.Name;
                oldPreformer.Surname = preformer.Surname;
                oldPreformer.Biography = preformer.Biography;
                oldPreformer.Picture = preformer.Picture;
                oldPreformer.Type = preformer.Type;
                oldPreformer.SoloCareer = preformer.SoloCareer;
                oldPreformer.BendCareer = preformer.BendCareer;
                save();
            }
        }
        public void save()
        {
            try
            {
                string json = JsonConvert.SerializeObject(preformers, Formatting.Indented, new JsonSerializerSettings
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

        public List<Preformer> loadFromFile()
        {
            List<Preformer> loadedPreformers = new List<Preformer>();

            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    loadedPreformers = JsonConvert.DeserializeObject<List<Preformer>>(json, new JsonSerializerSettings
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

            return loadedPreformers;
        }


    }
}

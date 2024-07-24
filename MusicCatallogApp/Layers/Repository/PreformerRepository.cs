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
                oldPreformer.Biography = preformer.Biography;
                oldPreformer.Picture = preformer.Picture;
                oldPreformer.Type = preformer.Type;
                oldPreformer.SoloCarrer = preformer.SoloCarrer;
                oldPreformer.BendCareer = preformer.BendCareer;
                save();
            }
        }

        public void save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    foreach (Preformer preformer in preformers)
                    {
                        file.WriteLine(preformer.StringToJson());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public List<Preformer> loadFromFile()
        {
            List<Preformer> loadedPreformers = new List<Preformer>();

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader file = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            Preformer preformer = JsonConvert.DeserializeObject<Preformer>(line);
                            loadedPreformers.Add(preformer);
                        }
                    }
                }
                preformers = loadedPreformers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return loadedPreformers;
        }
    }
}

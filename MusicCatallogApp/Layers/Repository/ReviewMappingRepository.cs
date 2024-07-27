using MusicCatallogApp.Layers.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatallogApp.Layers.Repository
{
    class ReviewMappingRepository
    {
        private static ReviewMappingRepository instance = null;
        private List<ReviewMapping> maps;
        private readonly string filePath = "../../../Layers/Data/reviewMapping.json";

        public ReviewMappingRepository()
        {
            maps = new List<ReviewMapping>();
            maps = loadFromFile();

        }

        public static ReviewMappingRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ReviewMappingRepository();
            }
            return instance;
        }

        public List<ReviewMapping> getAll()
        {
            return new List<ReviewMapping>(maps);
        }

        public ReviewMapping getById(int id)
        {
            foreach (ReviewMapping map in maps)
            {
                if (map.Id == id)
                {
                    return map;
                }
            }
            return null;
        }

        public int generateId()
        {
            int maxId = 0;
            foreach (ReviewMapping map in maps)
            {
                if (map.Id > maxId)
                {
                    maxId = map.Id;
                }
            }
            return maxId + 1;
        }

        public ReviewMapping add(ReviewMapping map)
        {
            map.Id = generateId();
            maps.Add(map);
            save();
            return map;
        }

        public void delete(int id)
        {
            ReviewMapping map = getById(id);
            if (map == null)
            {
                return;
            }
            maps.Remove(map);
            save();
        }

        public void update(ReviewMapping map)
        {
            ReviewMapping oldMap=getById(map.Id);
            if(oldMap != null)
            {
                oldMap.ItemId = map.ItemId;
                oldMap.ReviewIds = map.ReviewIds;
                save();
            }
        }

        public void save()
        {
            try
            {
                string json = JsonConvert.SerializeObject(maps, Formatting.Indented, new JsonSerializerSettings
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

        public List<ReviewMapping> loadFromFile()
        {
            List<ReviewMapping> loadedMaps = new List<ReviewMapping>();

            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    loadedMaps = JsonConvert.DeserializeObject<List<ReviewMapping>>(json, new JsonSerializerSettings
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

            return loadedMaps;
        }

    }
}

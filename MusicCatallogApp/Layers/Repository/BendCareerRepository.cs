using MusicCatallogApp.Layers.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicCatallogApp.Layers.Repository
{
    internal class BendCareerRepository
    {
        private static BendCareerRepository instance = null;
        private List<BendCareer> bendCareers;
        private readonly string filePath = "../../../Layers/Data/bendCareer.json";

        private BendCareerRepository()
        {
            bendCareers = new List<BendCareer>();
        }

        public static BendCareerRepository getInstance()
        {
            if (instance == null)
            {
                instance = new BendCareerRepository();
            }
            return instance;
        }

        public List<BendCareer> getAll()
        {
            return new List<BendCareer>(bendCareers);
        }

        public BendCareer getById(int id)
        {
            foreach (BendCareer bendCareer in bendCareers)
            {
                if (bendCareer.Id == id)
                {
                    return bendCareer;
                }
            }
            return null;
        }

        public int generateId()
        {
            int maxId = 0;
            foreach (BendCareer bendCareer in bendCareers)
            {
                if (bendCareer.Id > maxId)
                {
                    maxId = bendCareer.Id;
                }
            }
            return maxId + 1;
        }

        public BendCareer add(BendCareer bendCareer)
        {
            bendCareer.Id = generateId();
            bendCareers.Add(bendCareer);
            save();
            return bendCareer;
        }

        public void delete(int id)
        {
            BendCareer bendCareer = getById(id);
            if (bendCareer == null)
            {
                return;
            }
            bendCareers.Remove(bendCareer);
            save();
        }

        public void update(BendCareer bendCareer)
        {
            BendCareer oldBendCareer = getById(bendCareer.Id);
            if (oldBendCareer != null)
            {
                oldBendCareer.Links = bendCareer.Links;
                oldBendCareer.Participants = bendCareer.Participants;
                oldBendCareer.Picture = bendCareer.Picture;
                oldBendCareer.Biography = bendCareer.Biography;
                oldBendCareer.BendRelease = bendCareer.BendRelease;
                oldBendCareer.Concert = bendCareer.Concert;
                save();
            }
        }

        public void save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    foreach (BendCareer bendCareer in bendCareers)
                    {
                        file.WriteLine(bendCareer.StringToJson());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public List<BendCareer> loadFromFile()
        {
            List<BendCareer> loadedBendCareers = new List<BendCareer>();

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader file = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            BendCareer bendCareer = JsonConvert.DeserializeObject<BendCareer>(line);
                            loadedBendCareers.Add(bendCareer);
                        }
                    }
                }
                bendCareers = loadedBendCareers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return loadedBendCareers;
        }
    }
}

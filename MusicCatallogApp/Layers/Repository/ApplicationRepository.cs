using MusicCatallogApp.Layers.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicCatallogApp.Layers.Repository
{
    internal class ApplicationRepository
    {
        private static ApplicationRepository instance = null;
        private List<Application> apps;
        private readonly string filePath = "../../../Layers/Data/app.json";

        private ApplicationRepository()
        {
            apps = new List<Application>();
        }

        public static ApplicationRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ApplicationRepository();
            }
            return instance;
        }

        public List<Application> getAll()
        {
            return new List<Application>(apps);
        }

        public Application getById(int id)
        {
            foreach (Application app in apps)
            {
                if (app.Id== id)
                {
                    return app;
                }
            }
            return null;
        }

        public int generateId()
        {
            int maxId = 0;
            foreach (Application app in apps)
            {
                if (app.Id > maxId)
                {
                    maxId = app.Id;
                }
            }
            return maxId + 1;
        }

        public Application add(Application app)
        {
            app.Id = generateId();
            apps.Add(app);
            save();
            return app;
        }

        public void delete(int id)
        {
            Application app = getById(id);
            if (app == null)
            {
                return;
            }
            apps.Remove(app);
            save();
        }

        public void update(Application app)
        {
            Application oldApp = getById(app.Id);
            if (oldApp != null)
            {
                oldApp.NumOfAccesses = app.NumOfAccesses;
                oldApp.NumOfViews = app.NumOfViews;
                save();
            }
        }

        public void save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    foreach (Application app in apps)
                    {
                        file.WriteLine(app.StringToJson());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public List<Application> loadFromFile()
        {
            List<Application> loadedApps = new List<Application>();

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader file = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            Application app = JsonConvert.DeserializeObject<Application>(line);
                            loadedApps.Add(app);
                        }
                    }
                }
                apps = loadedApps;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return loadedApps;
        }
    }
}

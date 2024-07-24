using MusicCatallogApp.Layers.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicCatallogApp.Layers.Repository
{
    internal class MusicEditorsRepository
    {
        private static MusicEditorsRepository instance = null;
        private List<MusicEditors> musicEditors;
        private readonly string filePath = "../../../Layers/Data/musicEditors.json";

        private MusicEditorsRepository()
        {
            musicEditors = new List<MusicEditors>();
        }

        public static MusicEditorsRepository getInstance()
        {
            if (instance == null)
            {
                instance = new MusicEditorsRepository();
            }
            return instance;
        }

        public List<MusicEditors> getAll()
        {
            return new List<MusicEditors>(musicEditors);
        }

        public MusicEditors getById(int id)
        {
            foreach (MusicEditors editor in musicEditors)
            {
                if (editor.Id == id)
                {
                    return editor;
                }
            }
            return null;
        }

        public int generateId()
        {
            int maxId = 0;
            foreach (MusicEditors editor in musicEditors)
            {
                if (editor.Id > maxId)
                {
                    maxId = editor.Id;
                }
            }
            return maxId + 1;
        }

        public MusicEditors add(MusicEditors editor)
        {
            editor.Id = generateId();
            musicEditors.Add(editor);
            save();
            return editor;
        }

        public void delete(int id)
        {
            MusicEditors editor = getById(id);
            if (editor == null)
            {
                return;
            }
            musicEditors.Remove(editor);
            save();
        }

        public void update(MusicEditors editor)
        {
            MusicEditors oldEditor = getById(editor.Id);
            if (oldEditor != null)
            {
                oldEditor.Name = editor.Name;
                oldEditor.Surname = editor.Surname;
                oldEditor.Email = editor.Email;
                oldEditor.Password = editor.Password;
                oldEditor.Favourites = editor.Favourites;
                oldEditor.ShowReviews = editor.ShowReviews;
                oldEditor.ShowConcact = editor.ShowConcact;
                oldEditor.Blocked = editor.Blocked;
                oldEditor.UserType = editor.UserType;
                oldEditor.NumOfInputContent = editor.NumOfInputContent;
                oldEditor.TasksList = editor.TasksList;
                save();
            }
        }

        public void save()
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    foreach (MusicEditors editor in musicEditors)
                    {
                        file.WriteLine(editor.StringToJson());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public List<MusicEditors> loadFromFile()
        {
            List<MusicEditors> loadedEditors = new List<MusicEditors>();

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader file = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            MusicEditors editor = JsonConvert.DeserializeObject<MusicEditors>(line);
                            loadedEditors.Add(editor);
                        }
                    }
                }
                musicEditors = loadedEditors;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return loadedEditors;
        }
    }
}

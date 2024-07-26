using MusicCatallogApp.Layers.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicCatallogApp.Layers.Repository
{
    internal class MusicalPieceRepository
    {
        private static MusicalPieceRepository instance = null;
        private List<MusicalPiece> musicalPieces;
        private readonly string filePath = "../../../Layers/Data/musicalPieces.json";

        private MusicalPieceRepository()
        {
            musicalPieces = new List<MusicalPiece>();
            musicalPieces = loadFromFile();
        }

        public static MusicalPieceRepository getInstance()
        {
            if (instance == null)
            {
                instance = new MusicalPieceRepository();
            }
            return instance;
        }

        public List<MusicalPiece> getAll()
        {
            return new List<MusicalPiece>(musicalPieces);
        }

        public MusicalPiece getById(int id)
        {
            foreach (MusicalPiece piece in musicalPieces)
            {
                if (piece.Id == id)
                {
                    return piece;
                }
            }
            return null;
        }

        public int generateId()
        {
            int maxId = 0;
            foreach (MusicalPiece piece in musicalPieces)
            {
                if (piece.Id > maxId)
                {
                    maxId = piece.Id;
                }
            }
            return maxId + 1;
        }

        public MusicalPiece add(MusicalPiece piece)
        {
            piece.Id = generateId();
            musicalPieces.Add(piece);
            save();
            return piece;
        }

        public void delete(int id)
        {
            MusicalPiece piece = getById(id);
            if (piece == null)
            {
                return;
            }
            musicalPieces.Remove(piece);
            save();
        }

        public void update(MusicalPiece piece)
        {
            MusicalPiece oldPiece = getById(piece.Id);
            if (oldPiece != null)
            {
                oldPiece.Name = piece.Name;
                oldPiece.Text = piece.Text;
                oldPiece.Picture = piece.Picture;
                oldPiece.CreationDate = piece.CreationDate;
                oldPiece.Participants = piece.Participants;
                save();
            }
        }

        public void save()
        {
            try
            {
               
                string json = JsonConvert.SerializeObject(musicalPieces,Formatting.Indented, new JsonSerializerSettings
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

        public List<MusicalPiece> loadFromFile()
        {
            List<MusicalPiece> loadedPieces = new List<MusicalPiece>();

            try
            {
                if (File.Exists(filePath))
                {

                    string json = File.ReadAllText(filePath);

                    loadedPieces = JsonConvert.DeserializeObject<List<MusicalPiece>>(json, new JsonSerializerSettings
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

            return loadedPieces;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vokhmyanina_GUN40_FinalTask.SaveLoadService
{
    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _basePath;

        public FileSystemSaveLoadService(string basePath)
        {
            if (string.IsNullOrWhiteSpace(basePath))
                throw new ArgumentException("Base path cannot be empty", nameof(basePath));

            _basePath = basePath;
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        public void SaveData(string data, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File identifier cannot be null or empty", nameof(fileName));
            }
            string filePath = Path.Combine(_basePath,$"{fileName}.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine(data);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error while saving data {ex.Message}");
            }
        }

        public string LoadData(string fileName) 
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File identifier cannot be null or empty", nameof(fileName));
            }
            string filePath = Path.Combine(_basePath, $"{fileName}.txt");

            if (!File.Exists(filePath))
            { 
                return string.Empty;
            }

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while loading data {ex.Message}");
                return string.Empty;
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public void SaveData(string data, string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("File identifier cannot be null or empty", nameof(id));
            }
            string filePath = Path.Combine(_basePath,$"{id}.txt");
            // smth else
        }

        public void LoadData(string id) 
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("File identifier cannot be null or empty", nameof(id));
            } 
        }

    }
}

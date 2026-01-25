using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vokhmyanina_GUN40_FinalTask.Profile;
using Vokhmyanina_GUN40_FinalTask.SaveLoadService;

namespace Vokhmyanina_GUN40_FinalTask
{
    public sealed class Casino // В ТЗ написано что зачем-то надо наследоваться от IGame ????
    {
        const string BASE_PATH = "../../../PlayerProfiles/";

        public FileSystemSaveLoadService FileManager;
        private PlayerProfile _player;

        public PlayerProfile Player => _player;

        public Casino()
        {
            FileManager = new FileSystemSaveLoadService(BASE_PATH);
        }

        public void CreatePlayer(string name, int bank) 
        {
            _player = new PlayerProfile(name, bank);
        }

        // TODO: в ТЗ написано что этот класс должен сохранять и загружать профиль игрока
        // не понятно почему тут, уточнить у ментора
        // или попытаться реализовать самой
        // или забить и оставить в лончере
    }
}

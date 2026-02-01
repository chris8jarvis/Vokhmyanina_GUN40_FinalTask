using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vokhmyanina_GUN40_FinalTask.CasinoGames;
using Vokhmyanina_GUN40_FinalTask.Profile;
using Vokhmyanina_GUN40_FinalTask.SaveLoadService;

namespace Vokhmyanina_GUN40_FinalTask.Launcher
{
    public sealed class LaunchCasino
    {
        private Casino _casino = new Casino();
        private PlayerProfile _player;

        public void LaunchGame() 
        {
            Console.WriteLine("Welcome to our casino.");

            string playerName = GetPlayerName();
            int bank = GetBankFromFile(playerName, _casino.FileManager); 

            _casino.CreatePlayer(playerName, bank); 
            _player = _casino.Player; 
            Console.WriteLine($"{_player.Name} your bank is {_player.Bank}");

            int sum = GetSumForBankFromUser();
            _player.IncreaseBank(sum);
            Console.WriteLine($"Your current bank is {_player.Bank}");

            while (true)
            {
                Console.WriteLine("Do you want to play a game? [y/n]");
                if (Console.ReadLine() != "y")
                {
                    break;
                }

                _casino.StartGame();

                if (_player.Bank <= 0)
                {
                    Console.WriteLine("No money? Kicked!");
                    _casino.FileManager.SaveData(_player.Bank.ToString(), _player.Name);
                    _casino.Dispose();
                    return;
                }

                Console.WriteLine($"Your bank: {_player.Bank}");
            }

            _casino.FileManager.SaveData(_player.Bank.ToString(), _player.Name);
            
            Console.WriteLine($"Your bank: {_player.Bank}");
            Console.WriteLine($"Goodbye {_player.Name}");

            _casino.Dispose(); // защита от утечки
        }

        private string GetPlayerName()
        {
            string userInput;
            while (true)
            {
                Console.WriteLine("Enter your name:");
                userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Name cannot be empty.");
                    continue;
                }
                Console.WriteLine($"Welcome, {userInput}");
                break;
            } 
            return userInput;  
        }

        private int GetBankFromFile(string playerName, FileSystemSaveLoadService fileManager)
        {
            int bank = 0;
            string fileData = fileManager.LoadData(playerName);
            if (!int.TryParse(fileData, out bank))
            {
                bank = 0;
            }

            return bank;
        }

        private int GetSumForBankFromUser()
        {
            int sum = 0;
            Console.WriteLine("Enter amount of money you want to add to your account or 0");
            if (!int.TryParse(Console.ReadLine(), out sum))
            {
                sum = 0;
            }
            return sum;
        }
    }
}

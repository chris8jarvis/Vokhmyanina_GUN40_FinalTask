using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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

        public void LaunchGame() //GameLoop
        {
            Console.WriteLine("Welcome to our casino.");

            //создаем игрока
            string playerName = GetPlayerName();
            int bank = GetBankFromFile(playerName, _casino.FileManager); //загружаем банк из файла

            _casino.CreatePlayer(playerName, bank); //создаем профиль игрока
            _player = _casino.Player; 
            Console.WriteLine($"{_player.Name} your bank is {_player.Bank}");

            //-== пополнение банка
            int sum = GetSumForBankFromUser();
            _player.IncreaseBank(sum);
            Console.WriteLine($"Your current bank is {_player.Bank}");

            //-== Choice of game (while)
            ChooseGame();


            //-== Game launch
            //-== 


            //-== MyAction
            //-== 

            //-== Save
            _casino.FileManager.SaveData(_player.Bank.ToString(), _player.Name);
            //-==
            Console.WriteLine($"Goodbye {_player.Name}");

            // уточнить у ментора WTF
            // 2.Если значение банка превышает максимально возможное значения, значение банка
            // уменьшается в два раза.При этом выводится сообщения “You wasted half of your
            // bank money in casino’s bar”
            // структуру и enum ТЗ "Игральные карты и кости"
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

        private void ChooseGame()
        {
            while (true)
            {
                Console.WriteLine("Text '1' to play Black Jack or '2' to play Dice Game");
                string userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    BlackJack blackJack = new BlackJack(); //создаем игру
                    blackJack.PlayGame(); //запускаем игру
                    break;
                }
                else if (userChoice == "2")
                {
                    DiceGame diceGame = new DiceGame(3, 1, 6);
                    diceGame.PlayGame();
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong choice. Try again.");
                }
            }

        }


        // либо бесконечный цикл с вопросом, хотим ли создать нового пользователя или выйти из программы
        // while с именем, профилем, банком, игрой
        // далее если пользователя создаём, ещё один бесконечный цикл с попыткой ввести в банк деньги, где он обязан ввести число, которое распарсится в int



        // цели
        // примечание: можно всё в одну функцию как свалку, а потом разбить на функции. или сразу как dungeon по функциям
        // приветствие. и попробовать один раз запустить программу, что она работает.
        // научиться работать с записью и чтением файлов. можно на тестовом коде
        // просьба ввести имя игрока.
        // чтение файла и анализ есть ли его профиль. то есть, попытка открыть файл, если его нет, создаётся новый файл.
        // после чтения (или не успешного чтения и создания), создается объект профиля. чтобы потом с ним работать
        // прощание (профиль.Name good bye)
        // запись в файл профиль игрока

        // подсказка, чтобы писать в папку с проектом, попробовать при создании объекта сейв лоад в него скормить ../ или что-то подобное
        // основная цель, научиться работать с директрориями и научиться писать и читать из/в основную папку проекта

        // Насоздовать прочие элементы на будущее из раздела "Игральные карты и кости"


        // потом launcher превратить в использование объекта Casino как в ТЗ
        // _casino = new Casino() 
        // просьба ввести имя игрока.
        // bufUserInput = чтение имени игрока
        // _player = _casino.GetPlayer(bufUserInput)
        // где GetPlayer должен вызывать _casino.TryLoadPlayer(bufUserInput)
        // если не получилось Load, то вызывается _casino.CreatePlayer()
        // подумать, иметь ли у казино поле типа класса FileSystemSaveLoadService _casino.FileManager
        // или же передать объект типа FileSystemSaveLoadService в метод GetPlayer
    }
}

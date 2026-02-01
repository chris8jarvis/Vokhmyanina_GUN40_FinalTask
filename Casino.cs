using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vokhmyanina_GUN40_FinalTask.CasinoGames;
using Vokhmyanina_GUN40_FinalTask.Profile;
using Vokhmyanina_GUN40_FinalTask.SaveLoadService;

namespace Vokhmyanina_GUN40_FinalTask
{
    public sealed class Casino
    {
        const string BASE_PATH = "../../../PlayerProfiles/";

        public FileSystemSaveLoadService FileManager;
        
        private PlayerProfile _player;
        private CasinoGameBase _currentGame;
        private int _currentBet;

        public PlayerProfile Player => _player;

        public Casino()
        {
            FileManager = new FileSystemSaveLoadService(BASE_PATH);
        }

        public void CreatePlayer(string name, int bank) 
        {
            _player = new PlayerProfile(name, bank);
        }

        private CasinoGameBase сhooseGame() 
        {
            while (true)
            {
                Console.WriteLine("Text '1' to play Black Jack or '2' to play Dice Game [1/2]");
                string userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    BlackJack blackJack = new BlackJack();
                    return blackJack;

                }
                else if (userChoice == "2")
                {
                    DiceGame diceGame = new DiceGame(3, 1, 6);
                    return diceGame;
                }
                else
                {
                    Console.WriteLine("Wrong choice. Try again.");
                }
            }
        }


        public void StartGame()
        {
            _currentGame = сhooseGame();

            SubscribeToGameEvents(_currentGame);

            _currentBet = makeBet();

            // Списание ставки
            _player.DecreaseBank(_currentBet);

            _currentGame.PlayGame();

        }

        private void SubscribeToGameEvents(CasinoGameBase game)
        {
            if (game == null) return;

            // deduction of the bid
            UnsubscribeFromGameEvents();

            // subscribe to a new game 
            _currentGame = game;
            _currentGame.OnWin += HandleWin;
            _currentGame.OnLoose += HandleLoose;
            _currentGame.OnDraw += HandleDraw;
        }
        
        private void UnsubscribeFromGameEvents()
        {
            if (_currentGame == null) return;

            _currentGame.OnWin -= HandleWin;
            _currentGame.OnLoose -= HandleLoose;
            _currentGame.OnDraw -= HandleDraw;
            _currentGame = null;
        }

        private int makeBet()
        {
            while (true)
            {
                Console.WriteLine("Enter amount of money you want to bet");
                if (int.TryParse(Console.ReadLine(), out int userInputBet) &&
                    userInputBet > 0 &&
                    userInputBet <= _player.Bank
                    )
                {
                    return userInputBet;
                }
                else
                {
                    Console.WriteLine("Wrong amount");
                }
            }
        }

        private void HandleWin()
        {
            Console.WriteLine("You won!");
            _player.IncreaseBank(_currentBet * 2);
        }

        private void HandleLoose()
        {
            Console.WriteLine("You lost!");
        }

        private void HandleDraw()
        {
            Console.WriteLine("Draw!");
            _player.IncreaseBank(_currentBet);
        }

        public void Dispose()
        {
            UnsubscribeFromGameEvents();

            _player = null;
            _currentGame = null;
        }
    }
}

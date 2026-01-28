using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vokhmyanina_GUN40_FinalTask.CardsAndDice;
using Vokhmyanina_GUN40_FinalTask.Exceptions;

namespace Vokhmyanina_GUN40_FinalTask.CasinoGames
{
    public sealed class DiceGame : CasinoGameBase
    {
        private List<DiceStruct> _diceList;
        private readonly int _diceCount;
        private readonly int _minValue;
        private readonly int _maxValue;

        public DiceGame(int diceCount, int minValue, int maxValue) : base()
        {
            if (diceCount <= 0)
            {
                throw new ArgumentException("Dice count must be positive", nameof(diceCount));
            }

            _diceCount = diceCount; //сохранение числа кубиков
            _minValue = minValue; //сохр мин и мах значения
            _maxValue = maxValue;

            FactoryMethod();
        }
        public override void PlayGame() 
        {
            Console.WriteLine($" Dice game started!");

            Console.WriteLine($"\n PLAYER'S TURN:");
            int playerScore = RollDiceAndCalculate("Player");
            
            Console.WriteLine($"\n COMPUTER'S TURN:");
            int computerScore = RollDiceAndCalculate("Computer");
            
            Console.WriteLine($"\n=== RESULTS ===");
            Console.WriteLine($"Player: {playerScore}");
            Console.WriteLine($"Computer: {computerScore}");

            if (playerScore > computerScore)
            {
                Console.WriteLine("PLAYER WINS!");
                OnWinInvoke();
            }
            else if (playerScore < computerScore)
            {
                Console.WriteLine("COMPUTER WINS!");
                OnLooseInvoke();
            }
            else
            {
                Console.WriteLine("DRAW!");
                OnDrawInvoke();
            }
        }
        protected override void FactoryMethod()
        {
            _diceList = new List<DiceStruct>();

            for (int i = 0; i < _diceCount; i++)
            {
                var dice = new DiceStruct(_minValue, _maxValue); //создаем кубие
                _diceList.Add(dice); //ккладем в лист
            }
        }

        private int RollDiceAndCalculate(string playerName)
        {
            int total = 0; //начальная сумма
            Console.WriteLine($"{playerName} rolls:");

            // Создаем новые кубики для каждого броска
            var tempDice = new List<DiceStruct>(); //кладем во временный лист
            for (int i = 0; i < _diceCount; i++)
            {
                var dice = new DiceStruct(_minValue, _maxValue); //создаем кубик
                tempDice.Add(dice);
                Console.WriteLine($"Dice {i + 1}: {dice.Number}"); //показываем значение
                total += dice.Number; //добавляем к сумме
            }

            Console.WriteLine($"Total: {total}"); //итог
            return total; //возврат суммы
        }
    }
    
}

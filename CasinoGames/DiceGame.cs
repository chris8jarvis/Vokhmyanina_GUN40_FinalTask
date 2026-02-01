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

        public override event Action OnWin = null;
        public override event Action OnLoose = null;
        public override event Action OnDraw = null;

        private List<DiceStruct> _diceList;
        private readonly int _diceCount;
        private readonly int _minValue;
        private readonly int _maxValue;

        public DiceGame(int diceCount, int minValue, int maxValue) : base()
        {

            _minValue = minValue; 
            _maxValue = maxValue;

            _diceCount = diceCount;
            FactoryMethod();
        }
        public override void PlayGame() 
        {
            Console.WriteLine($"Dice game started!");

            Console.WriteLine($"\n your turn:");
            int playerScore = RollDiceAndCalculate();
            
            Console.WriteLine($"\n Сroupier's turn:");
            int computerScore = RollDiceAndCalculate();
            
            Console.WriteLine($"\n=== RESULTS ===");
            Console.WriteLine($"Player: {playerScore}");
            Console.WriteLine($"Сroupier: {computerScore}");

            if (playerScore > computerScore)
            {
                OnWin?.Invoke(); 
            }
            else if (playerScore < computerScore)
            {
                OnLoose?.Invoke();
            }
            else
            {
                OnDraw?.Invoke();
            }
        }
        protected override void FactoryMethod()
        {
            _diceList = new List<DiceStruct>();

            for (int i = 0; i < _diceCount; i++)
            {
                var dice = new DiceStruct(_minValue, _maxValue);
                _diceList.Add(dice); 
            }
        }

        private int RollDiceAndCalculate()
        {
            int total = 0;
            for (int i = 0; i < _diceList.Count; i++)
            {
                int diceNumber = _diceList[i].Number;
                Console.WriteLine($"Dice {i + 1}: {diceNumber}");
                total += diceNumber;
            }

            Console.WriteLine($"Total: {total}");
            return total; 
        }
    }
    
}

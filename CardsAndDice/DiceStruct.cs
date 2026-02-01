using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vokhmyanina_GUN40_FinalTask.Exceptions;

namespace Vokhmyanina_GUN40_FinalTask.CardsAndDice
{
    public struct DiceStruct
    {
        private readonly int _min; 
        private readonly int _max = 6; 
        private static readonly Random _random = new Random();

        public readonly int Number => _random.Next(_min, _max + 1);

        public DiceStruct(int min, int max)
        {
            if (min < 1)
            {
                throw new WrongDiceNumberException(min, 1, _max);
            }

            if (max > _max)
            {
                throw new WrongDiceNumberException(max, 1, _max);
            }
            _min = min;
            _max = max;
        }
    }
}

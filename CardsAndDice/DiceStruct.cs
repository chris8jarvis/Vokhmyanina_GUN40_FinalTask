using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokhmyanina_GUN40_FinalTask.CardsAndDice
{
    public struct DiceStruct
    {
        private readonly int _min;
        private readonly int _max;
        private static readonly Random _random = new Random();
        public readonly int Number {get;}

        public DiceStruct(int min, int max)
        {
            _min = min;
            _max = max;
            Number = _random.Next(min, max + 1);
        }
    }
}

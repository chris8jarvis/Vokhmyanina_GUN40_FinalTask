using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vokhmyanina_GUN40_FinalTask.Exceptions;

namespace Vokhmyanina_GUN40_FinalTask.CardsAndDice
{
    public struct DiceStruct //сам кубик
    {
        //поля
        private readonly int _min; //мин число на кубике
        private readonly int _max; //макс число на куб
        private static readonly Random _random = new Random(); //генератор случайных чисел
        
        //свойство
        public readonly int Number {get;} //число выпавшее на кубике

        public DiceStruct(int min, int max)
        {
            if (min < 1)
            {
                throw new WrongDiceNumberException(min, 1, int.MaxValue);
            }

            if (max > int.MaxValue)
            {
                throw new WrongDiceNumberException(max, 1, int.MaxValue);
            }

            if (min > max)
            {
                throw new ArgumentException($"Min ({min}) cannot be bigger than Max ({max})");
            }

            //если проверки пройдены, сохраняем значения
            _min = min;
            _max = max;

            //бросание кубика
            Number = _random.Next(min, max + 1); //генерируем случайное число от min до max

        }

    }
}

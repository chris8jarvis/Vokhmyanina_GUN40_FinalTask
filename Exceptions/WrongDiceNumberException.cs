using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokhmyanina_GUN40_FinalTask.Exceptions
{
    public class WrongDiceNumberException : Exception //наследуетяс от стандартного класса exception
    {
        public int InvalidNumber { get; } //три свойства InvalidNumber=введенное пользователем число
        public int MinAllowed { get; } //минимально разрешенное число
        public int MaxAllowed { get; } //максимально разрешенное число

        //конструктор
        public WrongDiceNumberException(int number, int minAllowed, int maxAllowed)
            : base($"Incorrect number: {number}. Acceptable range: [{minAllowed}, {maxAllowed}]")
        {
            //свойства для хранения переданных в аргументах значений
            InvalidNumber = number;
            MinAllowed = minAllowed;
            MaxAllowed = maxAllowed;
        }
    }
}

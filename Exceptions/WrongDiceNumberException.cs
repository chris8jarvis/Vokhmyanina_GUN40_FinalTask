using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokhmyanina_GUN40_FinalTask.Exceptions
{
    public class WrongDiceNumberException : Exception 
    {
        public int InvalidNumber { get; }
        public int MinAllowed { get; }
        public int MaxAllowed { get; }

        public WrongDiceNumberException(int number, int minAllowed, int maxAllowed)
            : base($"Incorrect number: {number}. Acceptable range: [{minAllowed}, {maxAllowed}]")
        {
            InvalidNumber = number;
            MinAllowed = minAllowed;
            MaxAllowed = maxAllowed;
        }
    }
}

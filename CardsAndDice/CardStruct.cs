using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokhmyanina_GUN40_FinalTask.CardsAndDice
{
    public struct CardStruct
    {
        public readonly CardSuits Suits { get; }
        public readonly CardRank Rank { get; }

        public CardStruct(CardSuits suit, CardRank rank)
        {
            Suits = suit;
            Rank = rank;
        }
    }
}

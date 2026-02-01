using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vokhmyanina_GUN40_FinalTask.CardsAndDice;
using Vokhmyanina_GUN40_FinalTask.Exceptions;

namespace Vokhmyanina_GUN40_FinalTask.CasinoGames
{
    public sealed class BlackJack : CasinoGameBase
    {

        public override event Action OnWin = null;
        public override event Action OnLoose = null;
        public override event Action OnDraw = null;

        private Queue<CardStruct> _deck;

        public BlackJack() : base() 
        {
            _deck = new Queue<CardStruct>();
            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            List<CardStruct> allCards = new List<CardStruct>();

            foreach (CardSuits suit in Enum.GetValues(typeof(CardSuits))) 
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank))) 
                {
                    CardStruct card = new CardStruct(suit, rank);
                    allCards.Add(card);
                }
            }

            Shuffle(allCards);

            _deck.Clear();
            foreach (var card in allCards)
            {
                _deck.Enqueue(card);
            }

            Console.WriteLine($"Deck is ready: {_deck.Count} cards");
        }

        private void Shuffle(List<CardStruct> cards)
        {
            Random random = new Random();

            for (int i = 0; i < 100; i++) 
            {
                int index1 = random.Next(cards.Count); 
                int index2 = random.Next(cards.Count);

                CardStruct temp = cards[index1]; 
                cards[index1] = cards[index2];
                cards[index2] = temp;
            }
        }

        public override void PlayGame()
        {
            List<CardStruct> сroupierHand = new List<CardStruct>();
            List<CardStruct> playerHand = new List<CardStruct>();

            // starting with two cards
            takeCard(сroupierHand);
            takeCard(сroupierHand);
            takeCard(playerHand);
            takeCard(playerHand);

            while (true)
            {
                int сroupierScore = calcHand(сroupierHand);
                int playerScore = calcHand(playerHand);

                Console.WriteLine($"Сroupier's hand: {printHand(сroupierHand)}. Score: {сroupierScore}");
                Console.WriteLine($"Player's hand: {printHand(playerHand)}. Score: {playerScore}");

                bool bothHasMaximumScore = сroupierScore == 21 && playerScore == 21;
                bool bothOverloaded = сroupierScore > 21 && playerScore > 21;
                bool drawCondition = bothHasMaximumScore || bothOverloaded;

                if (drawCondition)
                {
                    OnDraw?.Invoke();
                    return;
                }
                else if (сroupierScore > 21 || сroupierScore < playerScore)
                {
                    OnWin?.Invoke();
                    return;
                }
                else if (playerScore > 21 || сroupierScore > playerScore)
                {
                    OnLoose?.Invoke();
                    return;
                }
                else
                {
                    takeCard(сroupierHand);
                    takeCard(playerHand);
                }
            }
        }

        private string printHand(List<CardStruct> cards)
        {
            return string.Join(", ", cards.Select(c => c.Rank.ToString()));
        }

        private void takeCard(List<CardStruct> cards)
        {
            if (_deck.Count == 0)
            {
                FactoryMethod();
            }

            cards.Add(_deck.Dequeue());
        }

        private int calcHand(List<CardStruct> cards)
        {
            int result = 0;
            foreach (var item in cards)
            {
                result += (int)item.Rank;
            }
            return result;
        }

        
    }
}

using CardGameOfWar.App.Enums;
using CardGameOfWar.App.Mosdels;

namespace CardGameOfWar.App.Models
{
    public static class OriginalCardDeck
    {
        private static List<Card> originalCardDeck = new();
        public static int cardsInDeck = 52;
        public static double winningRate = 0.75;

        public static List<Card> CardDeck { get {return originalCardDeck; } }

        static OriginalCardDeck()
        {
            ResetCardDeck();
        }
        public static void ResetCardDeck()
        {            
            originalCardDeck.Clear();

            originalCardDeck.Add(new Card { CardValue = CardEnum.Two, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Three, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Four, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Five, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Six, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Seven, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Eight, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Nine, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Ten, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Jack, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Queen, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.King, SuitValue = SuitEnum.Diamond });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Ace, SuitValue = SuitEnum.Diamond });

            originalCardDeck.Add(new Card { CardValue = CardEnum.Two, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Three, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Four, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Five, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Six, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Seven, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Eight, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Nine, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Ten, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Jack, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Queen, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.King, SuitValue = SuitEnum.Spades });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Ace, SuitValue = SuitEnum.Spades });

            originalCardDeck.Add(new Card { CardValue = CardEnum.Two, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Three, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Four, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Five, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Six, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Seven, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Eight, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Nine, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Ten, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Jack, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Queen, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.King, SuitValue = SuitEnum.Clubs });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Ace, SuitValue = SuitEnum.Clubs });

            originalCardDeck.Add(new Card { CardValue = CardEnum.Two, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Three, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Four, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Five, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Six, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Seven, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Eight, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Nine, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Ten, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Jack, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Queen, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.King, SuitValue = SuitEnum.Hearts });
            originalCardDeck.Add(new Card { CardValue = CardEnum.Ace, SuitValue = SuitEnum.Hearts });
        }
    }
}

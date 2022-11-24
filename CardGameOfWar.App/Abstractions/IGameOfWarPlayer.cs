using CardGameOfWar.App.Mosdels;

namespace CardGameOfWar.Abstractions
{
    public interface IGameOfWarPlayer
    {     
        public Card DrawCard();

        string ShowScoreDeck();
    }
}

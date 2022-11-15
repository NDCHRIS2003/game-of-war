using AutoFixture;
using CardGameOfWar.App.Models;
using CardGameOfWar.App.Mosdels;

namespace CardGameOfWar.Test
{
    public class PlayerTest
    {        
        private readonly Fixture fixture;
        public PlayerTest()
        {            
            fixture = new Fixture();
        }
        

        [Fact]
        public void ShouldDrawCardForPlayer()
        {
            var player = fixture.Build<Player>().Create();

            var result = player.DrawCard();
            
            Assert.IsType<Card>(result).Equals(player.CardDeck);            
        }
    }
}

using CardGameOfWar.App.Controller;

namespace CardGameOfWar.App.Abstractions
{
    public  interface IGameEngineService
    {
        public IGameOfWarEngine GetGameEngine(int gameType)
        {
            switch (gameType)
            {
                case 0:
                    return new GameOfWarEngine();
                default:
                    throw new ApplicationException("Undefined Game");
            }
        }
    }
}

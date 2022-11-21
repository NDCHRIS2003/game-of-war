// See https://aka.ms/new-console-template for more information
using CardGameOfWar.App.Abstractions;
using CardGameOfWar.App.Models;
using CardGameOfWar.App.Service;
using Microsoft.Extensions.DependencyInjection;

while (true)
{
    try
    {

        Console.WriteLine("Choose a game to play and then press enter \n(Game Of War = 0)\nType \"Stop\" to exit");
        var gameNumber = Console.ReadLine()!;
        if (gameNumber.Equals("Stop", StringComparison.OrdinalIgnoreCase))
            break;
        if (int.TryParse(gameNumber, out var gameType))
        {
            var gameEngine = BuildGameEngine(gameType);

            OriginalCardDeck.ResetCardDeck();

            gameEngine.PlayGame();
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Incorrect option chosen for game. Choose again");
    }
}

IGameOfWarEngine BuildGameEngine(int gameType)
{
    //setup our DI
    var serviceProvider = new ServiceCollection()
        .AddSingleton<IGameEngineService, GameEngineService>()
        .BuildServiceProvider();

    var gameService = serviceProvider.GetService<IGameEngineService>();
    return gameService!.GetGameEngine(gameType);
}
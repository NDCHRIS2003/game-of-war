// See https://aka.ms/new-console-template for more information
using CardGameOfWar.App.Controller;

while (true) 
{
    try
    {
        var trumpNumber = string.Empty;
        int[] trumSuitRange = new[] { 0, 1, 2, 3 };

        Console.WriteLine("Choose a Trump Suite number to play game then press enter \n(Diamond = 0, Spades = 1, Clubs = 2, Hearts = 3)");
           
        trumpNumber = Console.ReadLine()!;

        if (trumpNumber.Equals("Stop", StringComparison.OrdinalIgnoreCase))
            break;
        if (trumSuitRange.Contains(int.Parse(trumpNumber)))
        {
            var gamingEngine = new GameController(int.Parse(trumpNumber));

            gamingEngine.PlayGame();

            Console.WriteLine("Press any number between 0,1,2,4 to play again or type stop to quit the game");
        }
        else
        {
            Console.WriteLine("Incorrect option chosen for Trump suite. Choose again");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Incorrect option chosen for Trump suite. Choose again");       
    }

}


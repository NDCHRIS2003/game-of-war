// See https://aka.ms/new-console-template for more information
using CardGameOfWar.App.Controller;

while (true) 
{
    try
    {
        ConsoleKeyInfo play;
        
        do
        {
            Console.WriteLine("Choose a Trump Suite (Diamond = 0, Spades = 1, Clubs = 2, Hearts = 3)");
           
            var trumpNumber = Console.ReadKey();           
           
            var gamingEngine = new GameController(GetConsoleKeyNumber(trumpNumber));
           
            gamingEngine.PlayGame();

            Console.WriteLine("Press 1 to play again");
            play = Console.ReadKey();
        } while (GetConsoleKeyNumber(play).Equals(1));
    }
    catch (Exception)
    {
        Console.WriteLine("Incorrect option chosen for Trump suite. Choose again");       
    }

}

static int GetConsoleKeyNumber(ConsoleKeyInfo number)
{
    if (char.IsDigit(number.KeyChar))
    {
        return int.Parse(number.KeyChar.ToString()); // use Parse if it's a Digit
    }
    return -1;  // Else we assign a default value
}

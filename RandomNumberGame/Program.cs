using RandomNumberGame;
using System.Diagnostics;



Console.WriteLine("Welcome to the game. Please choose the level. [E]-Easy, [M]-Medium, [H]-Hard"); //tavidan arasworad sheyvanasac davado validacia

bool userChooseValid = true;
char userInputInChar;



Game game = new Game();


do
{
    string difficulty = Console.ReadLine();
    userChooseValid = char.TryParse(difficulty, out userInputInChar);

    switch (userInputInChar)
    {
        case 'E':
            UI.DisplayMessage("Easy Mode:");
            game.Play(1, 10);
            break;

        case 'M':
            UI.DisplayMessage("Medium Mode:");
            game.Play(1, 50);
            break;

        case 'H':
            UI.DisplayMessage("Hard Mode:");
            game.Play(1, 100);
            break;

        default:
            Console.WriteLine("Please insert correct Character. Press [E]-Easy, [M]-Medium, [H]-Hard Game");
            break;
    }
} while (userInputInChar != 'E' || userInputInChar != 'M' || userInputInChar != 'H');


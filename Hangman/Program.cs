
using Hangman;

Console.WriteLine("Welcome to the Hangman");
List<string> Fruits = new List<string> { "apple", "banana", "orange", "grape", "kiwi", "strawberry", "pineapple", "blueberry" };
List<string> Animals = new List<string> { "lion", "wolf", "elephant", "monkey", "giraffe", "panda", "rabbit", "leopard"};
List<string> Countries = new List<string> { "georgia", "united States", "france", "germany", "england", "ireland", "poland", "spain" };


int x;

bool isUserInputValid = true;
bool isBetweenRanges = true;
string insertedWordNumber;
Game game = new Game();


do
{
    Console.WriteLine("You can choose which type of word you want to guess. [1] - Fruits, [2] - Animals, [3] - Countries");
    insertedWordNumber = Console.ReadLine();
    isUserInputValid = int.TryParse(insertedWordNumber, out x);
    isBetweenRanges = x >= 1 && x <= 3;
    if (!isUserInputValid)
    {
        Console.WriteLine("Invalid Input. Please enter a number between [1] - [3]");
    }
    else if (!isBetweenRanges)
    {
        Console.WriteLine("Invalid Input. Please enter numers between 1-3");
    }

}
while (!isUserInputValid || !isBetweenRanges);

switch (x)
{
    case 1:
        game.Play(Fruits);
            break;
    case 2:
        game.Play(Animals);
        break;
    case 3:
        game.Play(Countries);
        break;

}





/*

Console.WriteLine("Please Enter the Word");
string userWord = Console.ReadLine();
if (userWord == chosenWord)
{
    Console.WriteLine($"Congratulation you are right. The word was '{chosenWord}'");
}
else
{
    {
        Console.WriteLine($"Unfortunately you are wrong. The word was '{chosenWord}'");
    }
}
*/


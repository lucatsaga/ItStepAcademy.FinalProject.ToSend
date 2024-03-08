using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGame
{
    public class Game
    {
        public void Play(int minRange, int maxRange)
        {
            Random random = new Random();
            int targetNumber = random.Next(minRange, maxRange + 1); //გენერირდება Random რიცხვი 

            for (int i = 1; i <= 10; i++)
            {
                bool isUserInputValid = true;
                int x;
                bool isUserInputBetweenRanges = true;


                do
                {
                    UI.DisplayMessage($"Insert Number #{i}(Tries Left:{11 - i})");
                    string userGuess = Console.ReadLine();
                    isUserInputValid = int.TryParse(userGuess, out x);
                    isUserInputBetweenRanges = x >= minRange && x <= maxRange;
                    if (!isUserInputValid)
                    {
                        Console.WriteLine("Invalid input. Please enter only number");
                    }
                    else if (!isUserInputBetweenRanges)
                    {
                        Console.WriteLine($"Invalid input. Please enter numbers only between {minRange}-{maxRange}");

                    }
                }
                while (!isUserInputValid || !isUserInputBetweenRanges);


                if (x == targetNumber)
                {
                    UI.DisplayMessage("Congratulations, you have won. Inserted number is equal to the Random number");
                    return;
                }
                else if (i == 10)
                {
                    UI.DisplayMessage("Unfortunately, you have lost. You have used all the tries");
                }
                else
                {
                    UI.DisplayMessage(x > targetNumber
                        ? "Random number is lower than the Inserted number"
                        : "Random number is higher than the Inserted number");
                }
            }
        }
    }
}

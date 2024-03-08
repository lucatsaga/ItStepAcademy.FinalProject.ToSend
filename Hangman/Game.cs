using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Game
    {
        public void Play(List<string> ChosenWords)
        {
            bool isValid;
            Random random = new Random();
            int randomWordsNumber = random.Next(1, 8);
            bool userGuess = false;
            bool isLetterBetweenRanges = true;
            bool lastValid = true;
            string wholeWord;

            List<char> correctGuesses = new List<char>();

            UI.DisplayMessage($"The word to be guessed contains {ChosenWords[randomWordsNumber].Length} chars ");
            UI.DisplayMessage(new string('-', ChosenWords[randomWordsNumber].Length));

            for (int i = 1; i <= 6; i++)
            {
                do
                {
                    UI.DisplayMessage($"Try {i} (Tries left: {7 - i}). Please enter a letter from [a] to [z] ");
                    char userGuessChar;
                    string input = Console.ReadLine();
                    isValid = Char.TryParse(input, out userGuessChar);
                    isLetterBetweenRanges = userGuessChar >= 'a' && userGuessChar <= 'z';

                    if (isValid && isLetterBetweenRanges)
                    {
                        if (ChosenWords[randomWordsNumber].Contains(userGuessChar))
                        {
                            correctGuesses.Add(userGuessChar);
                        }

                        for (int j = 0; j < ChosenWords[randomWordsNumber].Length; j++)
                        {
                            if (correctGuesses.Contains(ChosenWords[randomWordsNumber][j]))
                            {
                                Console.Write($"{ChosenWords[randomWordsNumber][j]}");
                                userGuess = true;
                            }
                            else
                            {
                                Console.Write("-");
                            }
                        }

                        Console.WriteLine();
                    }
                    else
                    {
                        UI.DisplayMessage("Invalid Input. Please enter lowercase letters from [a] to [z]");
                    }

                } while (!isValid || !isLetterBetweenRanges);

            }

            if (userGuess)
            {
                do
                {
                    UI.DisplayMessage("Please Enter the whole Word, with symbols [a] --> [z]");
                    wholeWord = Console.ReadLine();

                    
                    bool hasInvalidCharacter = wholeWord.Any(c => !Char.IsLower(c) || c < 'a' || c > 'z');

                    if (hasInvalidCharacter)
                    {
                        UI.DisplayMessage("Invalid Input. The word should contain only lowercase letters from [a] to [z]. Please try again.");
                        lastValid = false;
                    }
                    else
                    {
                        lastValid = true;
                    }

                } while (lastValid == false);

                if (wholeWord == ChosenWords[randomWordsNumber])
                {
                    UI.DisplayMessage($"Congratulations you have won. The word was {ChosenWords[randomWordsNumber]}");
                }
                else
                {
                    UI.DisplayMessage($"Unfortunately you have lost. Try next time. The word was {ChosenWords[randomWordsNumber]}");
                }
            }
            else
            {
                UI.DisplayMessage($"Unfortunatelly you have missed all the tries. You have lost. Try next time.");
            }
        }
    }
}
    

               
            
        

                


            

            
        
    




    /*
     if (userGuess = true)
                        {
                            UI.DisplayMessage("Please Enter the whole Word");
                            string wholeWord = Console.ReadLine();
                            if(wholeWord == ChosenWords[randomWordsNumber])
                            {
                                UI.DisplayMessage($"Congratulations you have won. The word was {wholeWord}");
                            }
                            else
                            {
                                UI.DisplayMessage("Unfortunatelly you have lost. Try next time.");
                            }

                              


                        }
                    }
                    else
                    {
                        UI.DisplayMessage("Invalid Input. Please enter lowercase letters from [a] to [z]");
                    }
    */
   

static void Plus()
{

    char endProcessInput;
    bool isFirstIteration = true;
    {
        do
        {
            if (isFirstIteration)
            {
                Console.WriteLine("Hello welcome to the Calculator");
                isFirstIteration = false;
            }
            else
            {
                Console.WriteLine("Hello Again");
            }



            int x;
            bool isValidX = true;
            do
            {
                Console.WriteLine("Please type #1 Number");
                string inputX = Console.ReadLine();
                isValidX = int.TryParse(inputX, out x);

                if (!isValidX)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

            } while (!isValidX);

            int y;
            bool isValidY = true;
            do
            {
                Console.WriteLine("Please type #2 Number");
                string inputY = Console.ReadLine();
                isValidY = int.TryParse(inputY, out y);

                if (!isValidY)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

            } while (!isValidY);

            char z;
            bool isValidZ = true;
            bool isOperation = true;
            do
            {
                Console.WriteLine("Please type the arithmetic operation: 1.(+) - for sum 2.(-) for subtraction 3.(*) - for multiplication 4.(/) - for division");
                string inputZ = Console.ReadLine();
                isValidZ = char.TryParse(inputZ, out z);

                if (!isValidZ || (z != '+' && z != '-' && z != '*' && z != '/'))
                {
                    isOperation = false;
                    Console.WriteLine("Invalid operation. Please enter a valid operation (+, -, *, /).");
                }
                else
                {
                    isOperation = true;
                }

            } while (!isValidZ || !isOperation);

            switch (z)
            {
                case '+':
                    Console.WriteLine($"Sum is {x + y}");
                    break;
                case '-':
                    Console.WriteLine($"Subtraction is {x - y}");
                    break;
                case '*':
                    Console.WriteLine($"Multiplication is {x * y}");
                    break;
                case '/':
                    if (y != 0)
                    {
                        Console.WriteLine($"Division is {x / y}");
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero. Please enter a non-zero value for the second number.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation. Please enter a valid operation (+, -, *, /).");
                    break;
            }



            bool isValidEndInput = true;
            bool isValidEndingProcess = true;

            do
            {
                Console.WriteLine("Do you want to continue the process? Press (Y) --> To continue, Press (N) --> To close the calculator");
                string inputProcess = Console.ReadLine();
                isValidEndInput = char.TryParse(inputProcess, out endProcessInput);

                if (!isValidEndInput || endProcessInput != 'Y' && endProcessInput != 'N')
                {
                    Console.WriteLine("Invalid Character, please instert correct character to close or continue the process");
                    isValidEndingProcess = false;
                }
                else
                {
                    isValidEndingProcess = true;
                }
            } while (!isValidEndInput || !isValidEndingProcess);
        } while (endProcessInput == 'Y');
    }
}




Plus();
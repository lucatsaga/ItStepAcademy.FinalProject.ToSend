using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AtmOperations;
using Newtonsoft.Json;


class Program
{

    private const string FilePath = @"../../../customers.json";
    
    
    FileLogger fileLogger = new FileLogger();
    static void Main()
    {
        char lastOperation;

        List<Customer> customers = LoadCustomers();
        Customer currentCustomer = new Customer();
        FileLogger fileLogger = new FileLogger();
        bool isValid3 = false;
        char x;
        bool isValid4 = false;
        char y;
        
        




        Console.WriteLine("Welcome To the Bank");
        Console.WriteLine("Please Enter your Private Number");
        string insertPrivNum = Console.ReadLine();
        Customer existingCustomer = customers.FirstOrDefault(c => c.PrivateNumber == insertPrivNum);
        if (existingCustomer != null)
        {
            string enteredPassword;
            do
            {
                Console.WriteLine("Enter your password");
                enteredPassword = Console.ReadLine();
                if (enteredPassword == existingCustomer.Password)
                {
                    currentCustomer = existingCustomer;
                    Console.WriteLine($"Login successful! Welcome, {currentCustomer.FirstName} {currentCustomer.LastName}");
                }
                else
                {
                    Console.WriteLine("Incorrect password. Please write the correct one");
                }
            } while (enteredPassword != existingCustomer.Password);
        }
        else
        {
            currentCustomer.PrivateNumber = insertPrivNum;
            do
            {
                Console.WriteLine("Welcome, you are new member of the Bank");
                Random random = new Random();
                string randomPass = random.Next(1000, 10000).ToString();
                existingCustomer = customers.FirstOrDefault(c => c.Password == randomPass);
                if (existingCustomer == null)
                {
                    Console.WriteLine($"Your password is {randomPass}");
                    currentCustomer.Password = randomPass;
                }
                else
                {

                }
            } while (existingCustomer != null);



            Console.WriteLine("Please Fill you First Name");
            string fName;
            bool isValid;
            do
            {
                isValid = true; 
                fName = Console.ReadLine();

                for (int i = 0; i < fName.Length; i++)
                {
                    if (!(fName[i] >= 'a' && fName[i] <= 'z') && !(fName[i] >= 'A' && fName[i] <= 'Z'))
                    {
                        isValid = false;
                    }
                }

                if (!isValid)
                {
                    Console.WriteLine("Incorrect Value. Please enter characters [a] -- [z] OR [A] -- [Z]");
                }
            } while (!isValid);


            currentCustomer.FirstName = fName;
            Console.WriteLine("Please Fill you Last Name");
            string lName;
            bool isValid2;
            do
            {
                isValid2= true;
                lName = Console.ReadLine();
                for (int i = 0; i < lName.Length; i++)
                {
                    if (!(lName[i] >= 'a' && lName[i] <= 'z') && !(lName[i] >= 'A' && lName[i] <= 'Z'))
                    {
                        isValid2 = false;
                    }
                }
                if (isValid2 == false)
                {
                    Console.WriteLine("Incorrect Value. Please enter character [a] -- [z]  OR [A] -- [Z]");
                }
            } while (isValid2 == false);
            currentCustomer.LastName = lName;
            currentCustomer.Balance = 0;

            customers.Add(currentCustomer);
            SaveCustomers(customers, currentCustomer);

            Console.WriteLine("Registration successful!");

        }
        do
        {
            Console.WriteLine($"Choose Operation. 1.[B] --> To Check Balance" +
                $"2.[P] --> To Put Money into Account" +
                $"3.[T] --> To Withdraw Money" +
                $"4.[H] --> To See History of Operations ");

            do
            {
                string operation = Console.ReadLine();
                isValid3 = char.TryParse(operation, out x);



                if (isValid3)
                {
                    switch (x)
                    {
                        case 'B':
                            currentCustomer.CheckBalance();
                            FileLogger.Log($"The balance of ID{currentCustomer.Id}, {currentCustomer.FirstName} {currentCustomer.LastName} is {currentCustomer.Balance}Lari", currentCustomer);
                            break;
                        case 'P':
                            Console.WriteLine("Enter Amount, how much you want to put to Balance");
                            int putMoney = Convert.ToInt32(Console.ReadLine());
                            currentCustomer.PutMoney(putMoney);
                            FileLogger.Log($"{currentCustomer.FirstName} {currentCustomer.LastName} ID:{currentCustomer.Id} have added {putMoney} Lari to his/her account. Existing Balance is {currentCustomer.Balance}Lari", currentCustomer);
                            break;
                        case 'T':
                            Console.WriteLine("Enter Amount, how much you want to take from Balance");
                            int takeMoney = Convert.ToInt32(Console.ReadLine());
                            currentCustomer.TakeMoney(takeMoney);
                            FileLogger.Log($"{currentCustomer.FirstName} {currentCustomer.LastName} ID:{currentCustomer.Id} have withdrawn {takeMoney}Lari from his/her account. Existing Balance is {currentCustomer.Balance}Lari", currentCustomer);
                            break;
                        case 'H':
                            currentCustomer.History();

                            break;
                    }
                    SaveCustomers(customers, currentCustomer);
                }
                else
                {
                    Console.WriteLine("Incorrect value, please insert the correct one");
                }
            } while (isValid3 == false);

            Console.WriteLine("Do you want to Proceed the operation? " +
                "1.[Y] --> Continue" +
                "2.[N] --> Exit");
            do
            {
                string lastOperation2 = Console.ReadLine();
                isValid4 = char.TryParse(lastOperation2, out y);
                if (!isValid4)
                {
                    Console.WriteLine("Incorrect value, please insert the correct one");
                }
            } while (!isValid4 && (y != 'Y' || y != 'N'));
        } while (y == 'Y');








        /*
        foreach (Customer customer in customers)
        {
            Console.WriteLine($"{customer}");
        }
        */
    }
    static List<Customer> LoadCustomers()
    {
        List<Customer> customers = new List<Customer>();

        try
        {
            if (File.Exists(FilePath) && new FileInfo(FilePath).Length > 0)
            {
                string json = File.ReadAllText(FilePath);
                customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading customers: {ex.Message}");
        }

        return customers;
    }



    static void SaveCustomers(List<Customer> customers, Customer currentCustomer)
    {
        try
        {
            
            foreach (var customer in customers)
            {
                if (customer.Id == currentCustomer.Id)
                {
                    customer.Balance = currentCustomer.Balance;
                    break;
                }
            }

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving customers: {ex.Message}");
        }
    }
}








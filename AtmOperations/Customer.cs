using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AtmOperations
{
    public class Customer
    {
        public static int nextId { get; private set; } = 0;

        public int Id { get; set; }

        public string FirstName {  get; set; }




        public string LastName { get; set; }




        private string privateNumber;

        public string PrivateNumber
        {
            get { return privateNumber; }
            set
            {
                do
                {
                    if (value.Length == 11)
                    {
                        privateNumber = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Inserted Private Number doesn't contain 11 numbers");
                        Console.WriteLine("Please Re-Enter Private Number");
                        value = Console.ReadLine();
                    }
                } while (true);
            }
        }




        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length == 4)
                {
                    password = value;

                }
                else
                {
                    Console.WriteLine("Inserted Pin Code doesn't contain 4 Digits");
                }
            }
        }



        public decimal Balance { get; set; }

        public Customer customer { get; set; }

        public Customer(string firstName, string lastName, string privateNumber, string password, decimal balance)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PrivateNumber = privateNumber;
            this.Password = password;
            this.Balance = balance;

        }

        public Customer()
        {
            nextId++;
            Id = nextId;
        }

        public override string ToString() //for each-is dros stringad rom gamoitanos propertiebi
        {
            return $"Name: {FirstName} {LastName}, Password: {Password}, PersonalNumber: {PrivateNumber}";
        }


       

        public void DisplayUserInfo()
        {
            Console.WriteLine($"User(ID:{Id}, Name:{FirstName} {LastName}, PrivateNumber:{PrivateNumber}, Password:{Password}, Balance:{Balance})");
        }

        public void CheckBalance()
        {
            Console.WriteLine($"The balance of {FirstName} {LastName} is {Balance} Lari");


        }

        public void PutMoney(int money)
        {
            Balance += money;
            Console.WriteLine($"{FirstName} {LastName} have added {money} Lari to his/her account. {FirstName} {LastName}'s existing balance is {Balance}Lari");
        }

        public void TakeMoney(int money)
        {
            if (Balance >= money)
            {
                Balance -= money;
                Console.WriteLine($"{FirstName} {LastName} have withdrawn {money} Lari from his/her account. {FirstName} {LastName}'s existing balance is {Balance}Lari");
            }
            else
            {
                Console.WriteLine("Insufficient funds. Withdrawal failed.");
            }
        }
        public void History()
        {
            Console.WriteLine($"Transaction history of {FirstName} {LastName} (ID: {Id}):");
            try
            {
                string[] lines = File.ReadAllLines("../../../FileLogger.txt");

                foreach (string line in lines)
                {

                   if(line.Contains($"ID:{Id}"))
                        Console.WriteLine(line);
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading transaction history: {ex.Message}");
            }
        }
    }
}

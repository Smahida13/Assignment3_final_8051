using System;
using System.Collections.Generic;
using static ATMApplication.ATMApplication;
using System.Windows.Controls;
using System.Windows;
using ATMApp;

namespace ATMApplication
{

    public class ATMApplication
    {
        public static void Start()
        {
            // Create account
            var account = new BankAccount(1, "Curly Smith", 100.00, "123");

            Console.WriteLine("<-----Welcome to the ATM Application!---->");

            // User login
            Console.Write("Enter Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (account.VerifyCredentials(accountNumber, password))
            {
                Console.WriteLine("\nYou're logged in successfully!");
                ShowMenu(account);
            }
            else
            {
                Console.WriteLine(" Entered invalid account number or password.");
            }
        }

        static void ShowMenu(BankAccount account)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. View Bank Statement");
                Console.WriteLine("2. Deposit Funds");
                Console.WriteLine("3. Withdraw Funds");
                Console.WriteLine("4. View Transaction History");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nBank Statement:");
                        Console.WriteLine(account.GetBankStatement());
                        break;
                    case 2:
                        DepositFunds(account);
                        break;
                    case 3:
                        WithdrawalFunds(account);
                        break;
                    case 4:
                        account.DisplayTransactions();
                        break;
                    case 5:
                        Console.WriteLine("\nTHANK YOU for using the ATM.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine(" Your choice is . Please try again.");
                        break;
                }
            }
        }

        static void DepositFunds(BankAccount account)
        {
            Console.Write("\nEnter deposit amount: $");
            double amount = double.Parse(Console.ReadLine());
            account.Deposit(amount);
        }

        static void WithdrawalFunds(BankAccount account)
        {
            Console.Write("\nEnter withdrawal amount: $");
            double amount = double.Parse(Console.ReadLine());
            account.Withdraw(amount);
        }
        public class BankAccount
        {
            public int AccountNumber { get; private set; }
            public string AccountHolderName { get; private set; }
            public double Balance { get; private set; }
            private string Password { get; set; }
            private List<string> Transactions { get; set; }

            public double InterestRate { get; private set; } = 0.03; // Default interest rate: 3%

            public BankAccount(int accountNumber, string accountHolderName, double initialBalance, string password)
            {
                AccountNumber = accountNumber;
                AccountHolderName = accountHolderName;
                Balance = initialBalance;
                Password = password;
                Transactions = new List<string> { $"Account created with initial balance: ${initialBalance}" };
            }

            // Verify account number and password
            public bool VerifyCredentials(int accountNumber, string password)
            {
                return AccountNumber == accountNumber && Password == password;
            }

            public string GetBankStatement()
            {
                return $"Account Holder: {AccountHolderName}\n" +
                       $"Account Number: {AccountNumber}\n" +
                       $"Balance: ${Balance:F2}\n" +
                       $"Interest Rate: {InterestRate * 100}%";
            }

            // Deposit money
            public void Deposit(double amount)
            {
                if (amount > 0)
                {
                    Balance += amount;
                    Transactions.Add($"Deposited: ${amount:F2}");
                    Console.WriteLine($"successfully deposited amount. your Current Balance is: ${Balance:F2}");
                }
                else
                {
                    Console.WriteLine(" your deposited amount is invalid.");
                }
            }

            // Withdraw money
            public void Withdraw(double amount)
            {
                if (amount > 0 && amount <= Balance)
                {
                    Balance -= amount;
                    Transactions.Add($"Withdrew: ${amount:F2}");
                    Console.WriteLine($" successfully Withdrew amount. your Current Balance is : ${Balance:F2}");
                }
                else
                {
                    Console.WriteLine("insufficient funds.");
                }
            }

            // Display transaction history
            public void DisplayTransactions()
            {
                Console.WriteLine("\n Account Transaction History:");
                foreach (var transaction in Transactions)
                {
                    Console.WriteLine(transaction);
                }
            }

            internal object GetStatement()
            {
                throw new NotImplementedException();
            }
        }

    }
}


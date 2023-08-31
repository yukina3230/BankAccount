using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount;

public class CustomerService
{
    private int id;
    private CustomerAccount custAccount;

    public CustomerService()
    {
        id = 0;
        custAccount = new CustomerAccount();
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine("--- SAMPLE BANK APP ---");
        MenuScreen();
    }

    private void MenuScreen()
    {
        Console.Write("Please pick your option: \n1. Create New Account \n2. Add Fund \n3. Withdraw Fund \n4. Check Account Info \nPick: ");
        int option;
        bool isNumber = Int32.TryParse(Console.ReadLine(), out option); // To avoid entering characters
        if (!isNumber) option = 0;
        switch (option)
        {
            case 1: // Create Account
                CreateAccount();
                break;
            case 2: // Add Fund
                AddFund();
                break;
            case 3: // Withdraw Fund
                WithdrawFund();
                break;
            case 4: // Check Account Info
                ShowAccountInfo();
                break;
            default: // Default return to main menu
                Run();
                break;
        }
    }

    private void CreateAccount()
    {
        int newID = id + 1;
        string uniqueID = DateTime.Now.Year.ToString("") + newID.ToString("D4");
        custAccount = new CustomerAccount(); // Clear old data
        while (true)
        {
            Console.WriteLine("\n-- CREATE --");
            Console.Write("Please enter your Account name: ");
            custAccount.CustomerAccountName = Console.ReadLine()?.Trim();

            if (custAccount.CustomerAccountName?.Length < 9)
            {
                Console.Write("> ERROR: \"Account name must be more than 9 letters! Please try again.\"");
                Console.ReadKey(); Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Account created successfully!");
                Console.Write($"Your ID is: {uniqueID}.");
                custAccount.CustomerID = uniqueID; id = newID;
                Console.ReadKey(); Run(); break;
            }
        }
    }

    private void AddFund()
    {
        CheckAccountExist();
        while (true)
        {
            Console.WriteLine("\n-- TOP UP --");
            Console.Write("Please enter the Amount: ");
            double newAmount = Convert.ToDouble(Console.ReadLine());
            if (newAmount < 10000 || newAmount > 50000)
            //Customer can only Add between 1000 and 50000
            {
                Console.Write("> ERROR: \"The Amount have to be between 10000 and 50000!\"");
                Console.ReadKey(); Console.WriteLine();
            }
            else
            {
                custAccount.InitialFund += newAmount;
                Console.WriteLine($"{newAmount} added to your account!\nYour balance is {custAccount.InitialFund}.");
                Console.ReadKey(); Run(); break;
            }
        }
    }

    private void WithdrawFund()
    {
        CheckAccountExist();
        while (true)
        {
            Console.WriteLine("\n-- WITHDRAW --");
            Console.Write("Please enter the Amount: ");
            double withdrawAmount = Convert.ToDouble(Console.ReadLine());

            // Customer cannot withdraw more than the balance
            if (withdrawAmount > custAccount.InitialFund)
            {
                Console.Write("> ERROR: \"You do not have enough money to withdraw!\"");
                Console.ReadKey(); Console.WriteLine(); Run();
                continue;
            }

            // Customer can only Withdraw the money they have and it have to be between 10000 and 50000
            if (withdrawAmount < 10000 || withdrawAmount > 50000)
            {
                Console.Write("> ERROR: \"The Withdraw Amount have to be between 10000 and 50000!\"");
                Console.ReadKey(); Console.WriteLine();
            }
            else
            {
                custAccount.InitialFund -= withdrawAmount;
                Console.WriteLine($"You withdrew {withdrawAmount}!\nYour balance is {custAccount.InitialFund}.");
                Console.ReadKey(); Run(); break;
            }
        }
    }

    private void ShowAccountInfo()
    {
        CheckAccountExist();
        Console.WriteLine($"Your ID: {custAccount.CustomerID}");
        Console.WriteLine($"Your Account Name: {custAccount.CustomerAccountName}");
        Console.WriteLine($"Current Fund: {custAccount.InitialFund}");
        Console.ReadKey(); Run();
    }

    private void CheckAccountExist()
    {
        if (custAccount.CustomerID == null)
        {
            Console.Write("You have not create an account yet! Please try again.");
            Console.ReadKey(); Run();
        }
    }
}

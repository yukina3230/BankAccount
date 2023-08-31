using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount;

public class CustomerService
{
    private int id;
    public CustomerAccount custAccount { get; set; }

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
        int option = int.Parse(Console.ReadLine());
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
            Console.Write("Please enter your Account name: ");
            custAccount.CustomerAccountName = Console.ReadLine()?.Trim();

            if (custAccount.CustomerAccountName?.Length < 9)
            {
                Console.Write("> ERROR: \"Account name must be more than 9 letters! Please try again.\"");
            }
            else
            {
                Console.WriteLine("Account created successfully");
                Console.Write($"Your ID is: {uniqueID}");
                custAccount.CustomerID = uniqueID;
                id = newID; Console.ReadKey(); Run(); break;
            }
        }
    }

    private void AddFund()
    {
        CheckAccountExist();
        while (true)
        {
            Console.Write("Please enter the Amount: ");
            double newAmount = Convert.ToDouble(Console.ReadLine());
            if (newAmount < 10000 || newAmount > 50000)
            //Customer can only Add between 1000 and 50000
            {
                Console.Write("> ERROR: \"The Amount have to be between 10000 and 50000\"");
            }
            else custAccount.InitialFund += newAmount; Run(); break;
        }
    }

    private void WithdrawFund()
    {
        CheckAccountExist();
        while (true)
        {
            Console.Write("Please enter the Amount: ");
            double withdrawAmount = Convert.ToDouble(Console.ReadLine());
            if (withdrawAmount < 10000 || withdrawAmount > 50000 || withdrawAmount > custAccount.InitialFund)
            //Customer can only Withdraw the money they have and it have to be between 10000 and 50000
            {
                Console.Write("> ERROR: \"The Withdraw Amount have to be between 10000 and 50000\"");
            }
            else custAccount.InitialFund -= withdrawAmount; Run(); break;
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

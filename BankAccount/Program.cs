using System.ComponentModel;
using System.Security.Cryptography;

namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UniqueNumber will be added as string to ID and increase by 1 each time an account created, avoid duplicate ID
            int UniqueNumber = 1000;
            string CustomerID = "";
            string CustomerAccountName = "";
            decimal InitialFund = 0;

            //First time Account 
            MenuOption.CreateAccount(ref CustomerID, ref CustomerAccountName, ref InitialFund, ref UniqueNumber);
            MenuOption.AccountInfo(CustomerID, CustomerAccountName, InitialFund);
            MenuScreen(ref CustomerAccountName, ref CustomerID, ref InitialFund, ref UniqueNumber);

        }

        static void MenuScreen(ref string CustomerAccountName, ref string CustomerID, ref decimal InitialFund, ref int i)
        {
            Console.WriteLine("Please pick your option: 1.Create New Account;2.Add Fund;3.Withdraw Fund;4.Check Account Info");
            int OptionNumb = Convert.ToInt32(Console.ReadLine());
            switch (OptionNumb)
            {
                case 1://Create Account

                    MenuOption.CreateAccount(ref CustomerID, ref CustomerAccountName, ref InitialFund, ref i);
                    MenuOption.AccountInfo(CustomerID, CustomerAccountName, InitialFund);
                    MenuScreen(ref CustomerID, ref CustomerAccountName, ref InitialFund, ref i);
                    break;
                case 2://Add Fund
                    MenuOption.AddFund(ref InitialFund);
                    MenuOption.AccountInfo(CustomerID, CustomerAccountName, InitialFund);
                    MenuScreen(ref CustomerID, ref CustomerAccountName, ref InitialFund, ref i);
                    break;
                case 3://Withdraw Fund
                    MenuOption.WithdrawFund(ref InitialFund);
                    MenuOption.AccountInfo(CustomerID, CustomerAccountName, InitialFund);
                    MenuScreen(ref CustomerID, ref CustomerAccountName, ref InitialFund, ref i);
                    break;
                case 4://Check Account Info
                    MenuOption.AccountInfo(CustomerID, CustomerAccountName, InitialFund);
                    MenuScreen(ref CustomerID, ref CustomerAccountName, ref InitialFund, ref i);
                    break;
            }


        }
    }
}
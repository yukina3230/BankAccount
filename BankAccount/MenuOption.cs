using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class MenuOption
    {
            // ok here we gu
            public static void CreateAccount(ref string CustomerID, ref string CustomerAccountName, ref decimal InitialFund, ref int UniqueNumber)
            {
                Random rnd = new Random();
                string UniqueID = Convert.ToString(UniqueNumber);
                UniqueNumber++;
                //Increase UniqueNumber so next account ID will not have the same last number

                CustomerID = DateTime.Now.Year.ToString() + UniqueID;

                Console.WriteLine("Please enter your Account name");
                CustomerAccountName = Console.ReadLine();
                CustomerAccountName.Replace(" ", "");//Remove white space in Account Name
                if (CustomerAccountName.Length < 9)
                {
                    Console.WriteLine("You need at least 9 Letter in your account name");
                    CreateAccount(ref CustomerID, ref CustomerAccountName, ref InitialFund, ref UniqueNumber);
                }
                //Generate an Account
                CustomerAccount Account1 = new CustomerAccount(CustomerID, CustomerAccountName, InitialFund);
                Console.WriteLine("Account Created Successfully");

            }


            public static void AddFund(ref decimal InitialFund)
            {
                Console.WriteLine("Please Enter The Amount:");
                decimal InsertAmount = Convert.ToDecimal(Console.ReadLine());
                if (InsertAmount < 10000 || InsertAmount > 50000)
                //Customer can only Add between 1000 and 50000
                {
                    Console.WriteLine("The Insert Amount have to be between 10000 and 50000");
                    AddFund(ref InitialFund);
                }

                InitialFund += InsertAmount;
            }


            public static void WithdrawFund(ref decimal InitialFund)
            {
                Console.WriteLine("Please Enter The Amount:");
                decimal WithdrawAmount = Convert.ToDecimal(Console.ReadLine());
                if (WithdrawAmount < 10000 || WithdrawAmount > 50000 || WithdrawAmount > InitialFund)
                //Customer can only Withdraw the money they have and it have to be between 10000 and 50000
                {
                    Console.WriteLine("The Withdraw Amount have to be between 10000 and 50000");
                    WithdrawFund(ref InitialFund);
                }

                InitialFund -= WithdrawAmount;
            }


            public static void AccountInfo(string CustomerID, string CustomerAccountName, decimal IntitialFund)
            {
                Console.WriteLine($"Your ID: {CustomerID}");
                Console.WriteLine($"Your Account Name: {CustomerAccountName}");
                Console.WriteLine($"Current Fund: {IntitialFund}");
            }
    }
}

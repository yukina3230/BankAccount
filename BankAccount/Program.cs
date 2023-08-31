using System.ComponentModel;
using System.Security.Cryptography;

namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerService service = new CustomerService();
            service.Run();
        }
    }
}
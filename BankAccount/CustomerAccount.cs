using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class CustomerAccount
    {
        public string CustomerID { get; set; }
        public string CustomerAccountName { get; set; }
        public decimal InitialFund { get; set; }

        public CustomerAccount(string aCustomerID,string aCustomerAccountName,decimal aInitialFund) 
        {
            CustomerID = aCustomerID;
            CustomerAccountName = aCustomerAccountName;
            InitialFund = aInitialFund = 10000;
        }
        

    }
}

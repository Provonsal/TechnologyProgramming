using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lesson1.Base;

namespace lesson1.Tools
{
    class Logger
    {
        static public void CreatedAccount(long AccountNum, string Owner, decimal Balance, BankAccount.TypesAccounts type)
        {
            Log($"Account {AccountNum} was created successfully, Owner is {Owner}, Balance is {Balance}, Type is {type}.");
        }

        static public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

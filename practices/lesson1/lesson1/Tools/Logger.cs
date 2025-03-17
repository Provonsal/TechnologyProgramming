using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1.Tools
{
    class Logger
    {
        static public void CreatedAccount(long AccountNum, string Owner, decimal Balance)
        {
            string tmp = $"Account {AccountNum} was created successfully, Owner is {Owner}, Balance is {Balance}";
            Log(tmp);
        }

        static public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

using lesson1.Base;
using lesson1.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1
{
    class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string owner, decimal initialBalance)
            : base(owner, initialBalance) => Logger.CreatedAccount(AccountNum.Number, Owner, Balance, TypesAccounts.Credit);
        
        public override void PerformMonthlEndTransaction()
        {
            if (Balance > 500m)
            {
                MakeWitdrawl(Balance * 0.1m, DateTime.Now, "credit umenshaem");
            }
        }  
    }
}

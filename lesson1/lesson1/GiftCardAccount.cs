using lesson1.Base;
using lesson1.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1
{
    class GiftCardAccount : BankAccount
    {
        public GiftCardAccount(string owner, decimal initialBalance)
            : base(owner, initialBalance) => Logger.CreatedAccount(AccountNum.Number, Owner, Balance, TypesAccounts.Gift);

        public override void PerformMonthlEndTransaction()
        {
            if (Balance > 500m)
            {
                MakeWitdrawl(-Balance, DateTime.Now, "Dengi sgoreli pocherneli");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1.ValueObjects
{
    struct Transaction
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Note { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Note = note;
        }

        public override string ToString()
        {
            return $"Date: {Date}\tAmount: {Amount}\tNote: {Note}";
        }
    }
}

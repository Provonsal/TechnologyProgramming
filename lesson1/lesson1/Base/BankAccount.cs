using System;
using lesson1.ValueObjects;
using lesson1.Tools;
using System.Collections.Generic;
using System.Text;

namespace lesson1.Base
{
    abstract class BankAccount
    {
        /// <summary>
        /// Семя для айдишника аккаунта.
        /// </summary>
        private static UIDNumber s_accountseed = new(1000000000);

        /// <summary>
        /// Номер счета в банке.
        /// </summary>
        public UIDNumber AccountNum { get; }
        
        /// <summary>
        /// Фио владельца.
        /// </summary>
        public string Owner { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        private List<Transaction> _allTransactions = new List<Transaction>();

        public enum TypesAccounts
        {
            Debit,
            Credit,
            Gift
        }

        /// <summary>
        /// Баланс счета.
        /// </summary>
        public decimal Balance {
            get
            {
                decimal balance = 0;

                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }


        /// <summary>
        /// Конструктор, записывает в владельца его фио и присваивает счету его номер уникальный.
        /// </summary>
        /// <param name="fullname">ФИО владельца</param>
        /// <param name="initialBalance">Первоначальный баланс счета</param>
        protected BankAccount(string fullname, decimal initialBalance)
        {
            AccountNum = s_accountseed;
            s_accountseed.Number++;
            Owner = fullname;
            MakeDeposit(initialBalance, DateTime.Now, "Начальное пополнение баланса.");

            //Logger.CreatedAccount(AccountNum.Number, Owner, Balance);
        }

        /// <summary>
        /// Функция для пополнения баланса.
        /// </summary>
        /// <param name="amount">Количество денег для пополнения.</param>
        /// <param name="date">Дата когда эта операция произошла.</param>
        /// <param name="note">Заметка для операции.</param>
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(amount), 
                    "Amount of deposit must be above zero.");
            }
            else
            {
                var deposit = new Transaction(amount, date, note);
                _allTransactions.Add(deposit);
            }
        }

        /// <summary>
        /// Функция для списания средств со счета.
        /// </summary>
        /// <param name="amount">Количество денег для списания</param>
        /// <param name="date">Дата когда эта операция произошла.</param>
        /// <param name="note">Заметка для операции.</param>
        public void MakeWitdrawl(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    "Amount of withddrawl must be above zero.");
            }

            if (Balance - amount <= 0)
            {
                throw new InvalidOperationException("The balance have not enough money.");
            }
            
            var deposit = new Transaction(-amount, date, note);
            _allTransactions.Add(deposit);
            
        }

        public abstract void PerformMonthlEndTransaction();

        public string GetTransactionsHistory()
        {
            StringBuilder str = new();

            foreach (var trans in _allTransactions)
            {
                str.Append(trans.ToString() + '\n');
            }

            return str.ToString();
        }

    }
}

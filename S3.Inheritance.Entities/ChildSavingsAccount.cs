using System;
using System.Collections.Generic;
using System.Text;

namespace S3.Inheritance.Entities
{
    public class ChildSavingsAccount : Account
    {

        #region Fields
        private string childSsn;
        private int yearsLocked;
        #endregion

        #region Constructors
        public ChildSavingsAccount(int id, string accountNumber, decimal balance, DateTime created, decimal creditLimit, List<Transaction> transactions, string childSsn, int yearsLocked)
            :base(id, accountNumber, balance, created, creditLimit, transactions)
        {
            ChildSsn = childSsn;
            YearsLocked = yearsLocked;
        }

        public ChildSavingsAccount(string accountNumber, decimal balance, DateTime created, decimal creditLimit, List<Transaction> transactions, string childSsn, int yearsLocked)
            :this(default,accountNumber, balance, created, creditLimit, transactions, childSsn, yearsLocked)
        {

        }

        public ChildSavingsAccount()
        {

        }
        #endregion

        #region Properties
        public string ChildSsn { get => childSsn; set => childSsn = value; }
        public int YearsLocked { get => yearsLocked; set => yearsLocked = value; }
        #endregion

        #region Methods
        public DateTime CanBeWithdrawedFrom()
        {
            throw new NotImplementedException();
        }

        public override void Withdraw(decimal ammount)
        {
            throw new NotImplementedException();
        }

        public override void Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

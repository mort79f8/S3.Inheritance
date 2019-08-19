using System;
using System.Collections.Generic;
using System.Text;

namespace S3.Inheritance.Entities
{
    public class Account :Entity
    {
        #region Fields
        protected string accountNumber;
        protected decimal balance;
        protected DateTime created;
        protected decimal creditLimit;
        protected List<Transaction> transactions;
        #endregion

        #region Constructors
        public Account(int id,string accountNumber, decimal balance, DateTime created, decimal creditLimit, List<Transaction> transactions)
            :base(id)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            Created = created;
            CreditLimit = creditLimit;
            Transactions = transactions;
        }

        public Account(string accountNumber, decimal balance, DateTime created, decimal creditLimit, List<Transaction> transactions)
            : this(default, accountNumber, balance, created, creditLimit, transactions) { }

        public Account()
        {

        }
        #endregion

        #region Properties
        public string AccountNumber { get => accountNumber; set => accountNumber = value; }
        public decimal Balance { get => balance; set => balance = value; }
        public DateTime Created { get => created; set => created = value; }
        public decimal CreditLimit { get => creditLimit; set => creditLimit = value; }
        public List<Transaction> Transactions { get => transactions; set => transactions = value; }
        #endregion

        #region Methods
        public virtual void Withdraw(decimal amount)
        {
            var validateResult = ValidateAmount(amount);
            if (!validateResult.isValid)
            {
                throw new ArgumentException(validateResult.errorMsg);
            }
            else
            {
                Balance -= amount;
            }
        }

        public virtual void Deposit(decimal amount)
        {
            var validateResult = ValidateAmount(amount);
            if (!validateResult.isValid)
            {
                throw new ArgumentException(validateResult.errorMsg);
            }
            else
            {
                Balance += amount;
            }
        }

        public int GetDaysSinceCreation()
        {
            return (DateTime.Today - Created.Date).Days;
        }

        public static (bool isValid, string errorMsg) ValidateAmount(decimal amount)
        {
            if (amount < 0 || amount > 25000)
            {
                return (false, "Amount that is getting deposited is more that 25000 or less than 0");
            }
            else
            {
                return (true, "Amount is valid");
            }
        }

        public static (bool isValid, string errorMsg) ValidateAccountNumber(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public static (bool isValid, string errorMsg) ValidateCreatedDate(DateTime createdDate)
        {
            throw new NotImplementedException();
        }

        public static (bool isValid, string errorMsg) ValidateCreditLimit(decimal creditLimit)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}

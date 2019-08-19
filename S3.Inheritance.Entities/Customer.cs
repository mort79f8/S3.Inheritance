using System;
using System.Collections.Generic;
using System.Text;

namespace S3.Inheritance.Entities
{
    public class Customer: Person
    {
        #region Fields
        private List<Account> accounts;
        #endregion

        #region Constructors
        public Customer(int id, string firstName, string lastName, string ssn, List<Account> accounts)
            :base(id, firstName, lastName, ssn)
        {
            Accounts = accounts;
        }

        public Customer(string firstName, string lastName, string ssn, List<Account> accounts)
            :this(default, firstName, lastName, ssn, accounts)
        {

        }

        public Customer()
        {

        }
        #endregion

        #region Properties
        public List<Account> Accounts { get => accounts; set => accounts = value; }
        public int AccountFee { get; set; }
        public int MonthlyFreeTransactions { get; set; }
        public decimal TransactionFee { get; set; }
        public int Rating { get; set; }
        #endregion

        #region Methods
        public decimal GetDebts()
        {
            decimal debt = 0;
            foreach (var account in accounts)
            {
                if (account.Balance < 0)
                {
                    debt += account.Balance;
                }
            }

            return debt;
        }

        public decimal GetAssets()
        {
            decimal asserts = 0;
            foreach (var account in accounts)
            {
                if (account.Balance >= 0)
                {
                    asserts += account.Balance;
                }

            }

            return asserts;
        }

        public decimal GetTotalBalance()
        {
            decimal total = 0;
            foreach (var account in accounts)
            {
                total += account.Balance;
            }

            return total;
        }

        public decimal GetTotalFeesFor(DateTime year)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalFeesFor(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

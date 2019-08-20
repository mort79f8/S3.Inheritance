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
        public int Rating
        {
            get
            {
                if (GetDebts() < -2_500_000 && GetAssets() > 1_250_000)
                {
                    return 1;
                }
                else if (GetDebts() < -2_500_000 && (GetAssets() >= 50_000 && GetAssets() <= 1_250_000))
                {
                    return 2;
                }
                else if ((GetDebts() <= -250_000 && GetDebts() >= -2_500_000) && (GetAssets() >= 50_000 && GetAssets() <= 1_250_000))
                {
                    return 3;
                }
                else if ((GetDebts() < 0 && GetDebts() > -250_000) && (GetAssets() > 0 && GetAssets() <= 50_000) && (GetDebts() * -1) < GetAssets())
                {
                    return 4;
                }
                else if (((GetDebts() < 0 && GetDebts() > -250_000) && (GetAssets() > 0 && GetAssets() <= 50_000)))
                {
                    return 5;
                }
                else
                {
                    return 6;
                }
            }
        }
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
            // need to return the total of both transaction fees and cost of having X number of accounts.

        }

        public decimal GetTotalFeesFor(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        private int TransactionsForAMonth(Account account, int month, int year)
        {
            List<Transaction> transactionsThisMonth = new List<Transaction>();
            foreach (Transaction transaction in account.Transactions)
            {
                if (transaction.TimeStamp.Year == year && transaction.TimeStamp.Month == month)
                {
                    transactionsThisMonth.Add(transaction);
                }
            }
            return transactionsThisMonth.Count;
        }

        private decimal TransactionFeeForOneMonth(Account account, int month, int year)
        {
            int numberOfTransactions = TransactionsForAMonth(account, month, year);

            switch (Rating)
            {
                case 1:
                case 2:
                    if (numberOfTransactions <= 40)
                    {
                        return 0;
                    }
                    else
                    {
                        return (decimal)((numberOfTransactions - 40) * 0.78);
                    }
                case 3:
                case 4:
                    if (numberOfTransactions <= 20)
                    {
                        return 0;
                    }
                    else
                    {
                        return (decimal)((numberOfTransactions - 20) * 0.78);
                    }
                case 5:
                case 6:
                    if (numberOfTransactions <= 10)
                    {
                        return 0;
                    }
                    else
                    {
                        return (decimal)((numberOfTransactions - 10) * 0.78);
                    }
                default:
                    throw new ArgumentException("There is something wrong with the rating calculation, contact admin.");
            }
        }

        private decimal PriceForAccountsPrMonth()
        {
            if (Accounts.Count >=1 && Accounts.Count <= 3)
            {
                switch (Rating)
                {
                    case 1:
                    case 2:
                        return (decimal)23.00;
                    case 3:
                    case 4:
                        return (decimal)29.00;
                    case 5:
                    case 6:
                        return (decimal)38.00;
                    default:
                        throw new ArgumentException("Something is wrong contact admin");
                }
                
            }
            else if (Accounts.Count >= 4 && Accounts.Count <= 9)
            {
                switch (Rating)
                {
                    case 1:
                    case 2:
                        return (decimal)60.00;
                    case 3:
                    case 4:
                        return (decimal)87.00;
                    case 5:
                    case 6:
                        return (decimal)114.00;
                    default:
                        throw new ArgumentException("Something is wrong contact admin");
                }
            }
            else if (Accounts.Count > 9)
            {
                switch (Rating)
                {
                    case 1:
                    case 2:
                        return (decimal)6.00 * Accounts.Count;
                    case 3:
                    case 4:
                        return (decimal)13.00 * Accounts.Count;
                    case 5:
                    case 6:
                        return (decimal)19.75 * Accounts.Count;
                    default:
                        throw new ArgumentException("Something is wrong contact admin");
                }
                
            }
            else
            {
                throw new ArgumentException("Number of accounts is invalid");
            }
        }
        #endregion
    }
}

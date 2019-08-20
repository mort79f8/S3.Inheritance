using System;
using System.Collections.Generic;
using System.Text;

namespace S3.Inheritance.Entities
{
    public class Transaction : Entity
    {
        #region Fields
        private string sender;
        private string receiver;
        private decimal amount;
        private DateTime timeStamp;


        #endregion

        #region Constructors
        public Transaction(int id, string sender, string receiver, decimal amount, DateTime timeStamp)
            :base(id)
        {
            Sender = sender;
            Receiver = receiver;
            Amount = amount;
            if (timeStamp == default)
            {
                TimeStamp = DateTime.Now;
            }
            else
            {
                TimeStamp = timeStamp;
            }
        }

        public Transaction(string sender, string receiver, decimal amount)
            :this(default, sender, receiver, amount, default)
        {

        }

        public Transaction()
        {

        }
        #endregion

        #region Properties
        public string Sender { get => sender; set => sender = value; }
        public string Receiver { get => receiver; set => receiver = value; }
        public decimal Amount { get => amount; set => amount = value; }
        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        #endregion

        #region Methods
        public static (bool isValid, string errorMsg) ValidateTimeStamp(DateTime timeStamp)
        {
            // not allow to be in the future.
            if (timeStamp >= DateTime.Now)
            {
                return (false, "The date is in the future. Please check the date again.");
            }

            return (true, "date is good.");
        }

        public static (bool isValid, string errorMsg) ValidateAmount(decimal amount)
        {
            // 25000 max +-
            if (amount < -25000 || amount > 25000)
            {
                return (false, "Amount is below -25000 or above 25000");
            }

            return (true, "Amount is good");
        }
        #endregion
    }
}

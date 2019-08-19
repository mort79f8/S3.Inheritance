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
            TimeStamp = timeStamp;
        }

        public Transaction(string sender, string receiver, decimal amount, DateTime timeStamp)
            :this(default, sender, receiver, amount, timeStamp)
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
            throw new NotImplementedException();
        }

        public static (bool isValid, string errorMsg) ValidateAmount(decimal amount)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

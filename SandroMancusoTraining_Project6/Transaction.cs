using System;

namespace SandroMancusoTraining_Project6
{
    public class Transaction
    {
        public int Amount { get; }
        public DateTime Date { get; }

        public Transaction(int amount, DateTime date)
        {
            this.Amount = amount;
            this.Date = date;
        }
    }
}
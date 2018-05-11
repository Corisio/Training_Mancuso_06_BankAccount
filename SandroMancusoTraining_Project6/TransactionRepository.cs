using System.Collections.Generic;
using System.Linq;

namespace SandroMancusoTraining_Project6
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions;

        public TransactionRepository()
        {
            _transactions = new List<Transaction>();
        }

        public void Add(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public IList<Transaction> GetAll()
        {
            return _transactions.ToList();
        }
    }
}
using System.Collections;
using System.Collections.Generic;

namespace SandroMancusoTraining_Project6
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        IList<Transaction> GetAll();
    }
}
using System.Collections;
using System.Collections.Generic;

namespace SandroMancusoTraining_Project6
{
    public interface IStatementPrinter
    {
        void PrintStatement(IList<Transaction> transactions);
    }
}
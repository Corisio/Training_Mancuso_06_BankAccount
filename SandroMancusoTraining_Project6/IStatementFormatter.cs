using System.Collections;
using System.Collections.Generic;

namespace SandroMancusoTraining_Project6
{
    public interface IStatementFormatter
    {
        IEnumerable<string> GenerateStatement(IList<Transaction> transactions);
    }
}
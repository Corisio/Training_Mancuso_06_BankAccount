using System;
using System.Collections.Generic;

namespace SandroMancusoTraining_Project6
{
    public class StatementFormatter : IStatementFormatter
    {
        private const string HEADER = "DATE       | AMOUNT  | BALANCE";

        public IEnumerable<string> GenerateStatement(IList<Transaction> transactions)
        {
            return new List<string>()
            {
                HEADER
            };
        }
    }
}
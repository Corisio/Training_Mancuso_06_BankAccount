using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SandroMancusoTraining_Project6
{
    public class StatementFormatter : IStatementFormatter
    {
        private const string HEADER = "DATE | AMOUNT | BALANCE";

        public IEnumerable<string> GenerateStatement(IList<Transaction> transactions)
        {
            var formattedOutput = new List<string>();
            var balance = 0;

            formattedOutput.Add(HEADER);

            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
                formattedOutput.Add(
                    $"{transaction.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} | {transaction.Amount.ToString("###0.00", CultureInfo.InvariantCulture)} | {balance.ToString("###0.00", CultureInfo.InvariantCulture)}");
            }

            return formattedOutput;
        }
    }
}
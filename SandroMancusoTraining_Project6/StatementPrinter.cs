using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SandroMancusoTraining_Project6
{
    public class StatementPrinter : IStatementPrinter
    {
        private const string Header = "DATE | AMOUNT | BALANCE";

        public void PrintStatement(IList<Transaction> transactions)
        {
            var formattedOutput = new List<string>();
            var balance = 0;

            Console.WriteLine(Header);

            foreach (var transaction in transactions.OrderBy(t => t.Date))
            {
                balance += transaction.Amount;
                formattedOutput.Add(
                    $"{transaction.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} | {transaction.Amount.ToString("###0.00", CultureInfo.InvariantCulture)} | {balance.ToString("###0.00", CultureInfo.InvariantCulture)}");
            }

            for (var index = formattedOutput.Count - 1; index >= 0; index--)
            {
                Console.WriteLine(formattedOutput[index]);
            }
        }
    }
}
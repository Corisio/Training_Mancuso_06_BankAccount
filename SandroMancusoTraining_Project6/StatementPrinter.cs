using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SandroMancusoTraining_Project6
{
    public class StatementPrinter : IStatementPrinter
    {
        private const string Header = "DATE | AMOUNT | BALANCE";

        public void PrintStatement(IList<Transaction> transactions)
        {
            var formattedOutput = new StringBuilder();
            var balance = 0;

            formattedOutput.AppendLine(Header);

            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
                formattedOutput.AppendLine(
                    $"{transaction.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} | {transaction.Amount.ToString("###0.00", CultureInfo.InvariantCulture)} | {balance.ToString("###0.00", CultureInfo.InvariantCulture)}");
            }

            Console.Write(formattedOutput.ToString());
        }
    }
}
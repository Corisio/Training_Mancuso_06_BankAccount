using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace SandroMancusoTraining_Project6
{
    [TestFixture]
    public class StatementPrinterShould
    {
        private StringBuilder _fakeoutput;
        private static readonly string Header = "DATE | AMOUNT | BALANCE" + Environment.NewLine;

        [SetUp]
        public void SetUp()
        {
            _fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(_fakeoutput));
        }

        [Test]
        public void return_the_header_when_receiveing_an_empty_list()
        {
            var statementFormatter = new StatementPrinter();

            statementFormatter.PrintStatement(new List<Transaction>());

            String actualOutput = _fakeoutput.ToString();

            Assert.AreEqual(Header, actualOutput);
        }

        [Test]
        public void format_correctly_a_deposit()
        {
            var statementFormatter = new StatementPrinter();
            var date = new DateTime(2014, 4, 1);
            var transactions = new List<Transaction>()
            {
                new Transaction(1000, date)
            };

            statementFormatter.PrintStatement(transactions);

            String actualOutput = _fakeoutput.ToString();
            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("DATE | AMOUNT | BALANCE");
            expectedOutput.AppendLine("01/04/2014 | 1000.00 | 1000.00");
            Assert.AreEqual(expectedOutput.ToString(), actualOutput);
        }

        [Test]
        public void format_correctly_a_withdrawal()
        {
            var statementFormatter = new StatementPrinter();

            var date = new DateTime(2014, 4, 1);

            var transactions = new List<Transaction>()
            {
                new Transaction(-1000, date)
            };

            statementFormatter.PrintStatement(transactions);

            String actualOutput = _fakeoutput.ToString();
            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("DATE | AMOUNT | BALANCE");
            expectedOutput.AppendLine("01/04/2014 | -1000.00 | -1000.00");
            Assert.AreEqual(expectedOutput.ToString(), actualOutput);
        }

        [Test]
        public void print_transactions_in_reverse_order()
        {
            var statementFormatter = new StatementPrinter();

            var date1 = new DateTime(2014, 4, 1);
            var date2 = new DateTime(2014, 4, 2);

            var transactions = new List<Transaction>()
            {
                new Transaction(-1000, date1),
                new Transaction(2000, date2)
            };

            statementFormatter.PrintStatement(transactions);

            String actualOutput = _fakeoutput.ToString();
            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("DATE | AMOUNT | BALANCE");
            expectedOutput.AppendLine("02/04/2014 | 2000.00 | 1000.00");
            expectedOutput.AppendLine("01/04/2014 | -1000.00 | -1000.00");
            Assert.AreEqual(expectedOutput.ToString(), actualOutput);
        }
    }
}

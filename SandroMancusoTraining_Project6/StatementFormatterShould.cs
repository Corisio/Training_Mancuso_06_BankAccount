using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SandroMancusoTraining_Project6
{
    [TestFixture]
    public class StatementFormatterShould
    {
        private const string HEADER = "DATE | AMOUNT | BALANCE";

        [Test]
        public void return_the_header_when_receiveing_an_empty_list()
        {
            var statementFormatter = new StatementFormatter();

            IEnumerable<string> formattedStatement = statementFormatter.GenerateStatement(new List<Transaction>());

            Assert.AreEqual(HEADER, formattedStatement.First());
        }

        [Test]
        public void format_correctly_a_deposit()
        {
            var statementFormatter = new StatementFormatter();

            var date = new DateTime(2014, 4, 1);

            var transactions = new List<Transaction>()
            {
                new Transaction(1000, date)
            };

            IEnumerable<string> formattedStatement = statementFormatter.GenerateStatement(transactions);

            Assert.AreEqual("01/04/2014 | 1000.00 | 1000.00", formattedStatement.ElementAt(1));
        }
    }
}

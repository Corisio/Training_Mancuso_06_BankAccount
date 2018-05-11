using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SandroMancusoTraining_Project6
{
    [TestFixture]
    public class StatementFormatterShould
    {
        private const string HEADER = "DATE       | AMOUNT  | BALANCE";

        [Test]
        public void return_the_header_when_receiveing_an_empty_list()
        {
            var statementFormatter = new StatementFormatter();

            IEnumerable<string> formattedStatement = statementFormatter.GenerateStatement(new List<Transaction>());

            Assert.AreEqual(HEADER, formattedStatement.First());
        }
    }
}

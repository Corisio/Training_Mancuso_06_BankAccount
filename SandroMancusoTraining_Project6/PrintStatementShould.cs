using System;
using System.IO;
using System.Text;
using Moq;
using NUnit.Framework;

namespace SandroMancusoTraining_Project6
{
    [TestFixture]
    public class PrintStatementShould
    {
        private StringBuilder consoleOutput;
        private Mock<IDateTimeProvider> dateTimeProvider;
        private TransactionRepository repository;
        private StatementPrinter statementPrinter;
        private AccountService accountService;

        [SetUp]
        public void SetUp()
        {
            consoleOutput = new StringBuilder();
            Console.SetOut(new StringWriter(consoleOutput));
            dateTimeProvider = new Mock<IDateTimeProvider>();
            repository = new TransactionRepository();
            statementPrinter = new StatementPrinter();

            accountService = new AccountService(repository, dateTimeProvider.Object, statementPrinter);
        }

        [Test]
        public void show_every_transaction_with_its_accumulated_balance()
        {
            dateTimeProvider.SetupSequence(dp => dp.GetCurrentTime())
                .Returns(new DateTime(2014, 4, 1))
                .Returns(new DateTime(2014, 4, 2))
                .Returns(new DateTime(2014, 4, 10));

            accountService.Deposit(1000);
            accountService.Withdraw(100);
            accountService.Deposit(500);

            accountService.PrintStatement();

            var actualOutput = consoleOutput.ToString();

            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("DATE | AMOUNT | BALANCE");
            expectedOutput.AppendLine("10/04/2014 | 500.00 | 1400.00");
            expectedOutput.AppendLine("02/04/2014 | -100.00 | 900.00");
            expectedOutput.AppendLine("01/04/2014 | 1000.00 | 1000.00");

            Assert.AreEqual(expectedOutput.ToString(), actualOutput);
        }
        [Test]
        public void show_the_transactions_in_descending_order_by_date()
        {
            dateTimeProvider.SetupSequence(dp => dp.GetCurrentTime())
                .Returns(new DateTime(2014, 4, 2))
                .Returns(new DateTime(2014, 4, 1))
                .Returns(new DateTime(2014, 4, 10));

            accountService.Withdraw(100);
            accountService.Deposit(1000);
            accountService.Deposit(500);

            accountService.PrintStatement();

            String actualOutput = consoleOutput.ToString();

            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("DATE | AMOUNT | BALANCE");
            expectedOutput.AppendLine("10/04/2014 | 500.00 | 1400.00");
            expectedOutput.AppendLine("02/04/2014 | -100.00 | 900.00");
            expectedOutput.AppendLine("01/04/2014 | 1000.00 | 1000.00");

            Assert.AreEqual(expectedOutput.ToString(), actualOutput);
        }
    }
}

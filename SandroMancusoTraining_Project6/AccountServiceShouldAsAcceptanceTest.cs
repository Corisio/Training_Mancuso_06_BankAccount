using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalUtilities.Utilities;
using Moq;
using NUnit.Framework;

namespace SandroMancusoTraining_Project6
{
    [TestFixture]
    public class AccountServiceShouldAsAcceptanceTest   
    {
        [Test]
        public void print_statement_correctly_after_some_transactions()
        {
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            dateTimeProvider.SetupSequence(dp => dp.GetCurrentTime())
                .Returns(new DateTime(2014, 4, 1))
                .Returns(new DateTime(2014, 4, 2))
                .Returns(new DateTime(2014, 4, 10));

            ITransactionRepository repository = new TransactionRepository();

            var accountService = new AccountService(repository, dateTimeProvider.Object);

            accountService.Deposit(1000);
            accountService.Withdraw(100);
            accountService.Deposit(500);

            accountService.PrinStatement();
            
            String actualOutput = fakeoutput.ToString();

            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("DATE | AMOUNT | BALANCE");
            expectedOutput.AppendLine("10 / 04 / 2014 | 500.00 | 1400.00");
            expectedOutput.AppendLine("02 / 04 / 2014 | -100.00 | 900.00");
            expectedOutput.AppendLine("01 / 04 / 2014 | 1000.00 | 1000.00");

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
 }

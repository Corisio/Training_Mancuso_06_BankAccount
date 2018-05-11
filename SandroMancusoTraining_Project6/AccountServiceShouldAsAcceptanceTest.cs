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

            var mockedRepository = new Mock<IAccountRepository>();

            var accountService = new AccountService(mockedRepository.Object);

            accountService.Deposit(1000);
            accountService.Withdraw(100);
            accountService.Deposit(500);
            
            String output = fakeoutput.ToString();
            Approvals.Verify(output);

            //DATE | AMOUNT | BALANCE
            //10 / 04 / 2014 | 500.00 | 1400.00
            //02 / 04 / 2014 | -100.00 | 900.00
            //01 / 04 / 2014 | 1000.00 | 1000.00
        }
    }
 }

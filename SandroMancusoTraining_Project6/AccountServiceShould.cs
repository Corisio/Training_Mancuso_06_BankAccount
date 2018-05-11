using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace SandroMancusoTraining_Project6
{
    [TestFixture]
    public class AccountServiceShould
    {
        private Mock<ITransactionRepository> _transactionRepository;
        private Mock<IDateTimeProvider> _dateTimeProvider;
        private Mock<IStatementPrinter> _statementPrinter;
        private AccountService _accountService;

        [SetUp]
        public void SetUp()
        {
            _transactionRepository = new Mock<ITransactionRepository>();
            _dateTimeProvider = new Mock<IDateTimeProvider>();
            _statementPrinter = new Mock<IStatementPrinter>();
            _accountService = new AccountService(_transactionRepository.Object, _dateTimeProvider.Object, _statementPrinter.Object);
        }

        [Test]
        public void throw_invalid_repository_exception_when_initialized_with_null_account_repository()
        {
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            InvalidRepositoryException capturedException = null;
            ITransactionRepository repository = null;
            try
            {
                new AccountService(repository, dateTimeProvider.Object, _statementPrinter.Object);
            }
            catch (InvalidRepositoryException e)
            {
                capturedException = e;
            }

            Assert.IsNotNull(capturedException);
            Assert.AreEqual("Account", capturedException.RepositoryName);
        }
        [Test]
        public void throw_invalid_repository_exception_when_initialized_with_null_datetime_provider()
        {
            IDateTimeProvider dateTimeProvider = null;
            InvalidProviderException capturedException = null;
            Mock<ITransactionRepository> repository = new Mock<ITransactionRepository>();
            try
            {
                new AccountService(repository.Object, dateTimeProvider, _statementPrinter.Object);
            }
            catch (InvalidProviderException e)
            {
                capturedException = e;
            }

            Assert.IsNotNull(capturedException);
            Assert.AreEqual("DateTime", capturedException.RepositoryName);
        }

        [Test]
        public void deposit_should_store_transaction_in_repository()
        {
            var currentTime = new DateTime(2000, 1, 1);
            _dateTimeProvider.Setup(dtp => dtp.GetCurrentTime()).Returns(currentTime);

            _accountService.Deposit(100);

            _transactionRepository.Verify(ar =>
                ar.Add(It.Is<Transaction>(ao =>
                    ao.Amount == 100 && ao.Date == currentTime)));
        }

        [Test]
        public void withdraw_should_store_transaction_in_repository()
        {
            var currentTime = new DateTime(2000, 1, 1);
            _dateTimeProvider.Setup(dtp => dtp.GetCurrentTime()).Returns(currentTime);

            _accountService.Withdraw(100);

            _transactionRepository.Verify(ar =>
                ar.Add(It.Is<Transaction>(ao =>
                    ao.Amount == -100 && ao.Date == currentTime)));
        }

        [Test]
        public void get_all_transactions_when_printing_statement()
        {
            _accountService.PrintStatement();

            _transactionRepository.Verify(ar => ar.GetAll(), Times.Once);
        }

        [Test]
        public void send_all_transactions_to_the_statement_formatter_when_printing_statement()
        {
            var transactions = new List<Transaction>();
            _transactionRepository.Setup(tr => tr.GetAll()).Returns(transactions);

            _accountService.PrintStatement();

            _statementPrinter.Verify(sf => sf.PrintStatement(transactions), Times.Once);
        }
    }
}

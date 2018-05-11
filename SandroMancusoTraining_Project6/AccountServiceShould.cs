using System;
using Moq;
using NUnit.Framework;

namespace SandroMancusoTraining_Project6
{
    [TestFixture]
    public class AccountServiceShould
    {
        [Test]
        public void throw_invalid_repository_exception_when_initialized_with_null_account_repository()
        {
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            InvalidRepositoryException capturedException = null;
            ITransactionRepository repository = null;
            try
            {
                new AccountService(repository, dateTimeProvider.Object);
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
                new AccountService(repository.Object, dateTimeProvider);
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
            var accountRepository = new Mock<ITransactionRepository>();
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            var accountService = new AccountService(accountRepository.Object, dateTimeProvider.Object);
            var currentTime = new DateTime(2000, 1, 1);
            dateTimeProvider.Setup(dtp => dtp.GetCurrentTime()).Returns(currentTime);

            accountService.Deposit(100);

            accountRepository.Verify(ar =>
                ar.Add(It.Is<Transaction>(ao =>
                    ao.Amount == 100 && ao.Date == currentTime)));
        }

        [Test]
        public void withdraw_should_store_transaction_in_repository()
        {
            var accountRepository = new Mock<ITransactionRepository>();
            var dateTimeProvider = new Mock<IDateTimeProvider>();
            var accountService = new AccountService(accountRepository.Object, dateTimeProvider.Object);
            var currentTime = new DateTime(2000, 1, 1);
            dateTimeProvider.Setup(dtp => dtp.GetCurrentTime()).Returns(currentTime);

            accountService.Withdraw(100);

            accountRepository.Verify(ar =>
                ar.Add(It.Is<Transaction>(ao =>
                    ao.Amount == -100 && ao.Date == currentTime)));
        }
    }

    public interface IDateTimeProvider
    {
        DateTime GetCurrentTime();
    }
}

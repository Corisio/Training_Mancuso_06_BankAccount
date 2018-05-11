using System;
using System.Linq;
using NUnit.Framework;

namespace SandroMancusoTraining_Project6
{
    [TestFixture]
    public class TransactionRepositoryShould
    {
        private ITransactionRepository _transactionRepository;

        [SetUp]
        public void SetUp()
        {
            _transactionRepository = new TransactionRepository();
        }

        [Test]
        public void GetAllTransactionsAdded()
        {
            var firstAmount = 100; 
            var firstDate = new DateTime(2018, 1, 1);
            var secondAmount = 200;
            var secondDate = new DateTime(2018, 1, 2);
            _transactionRepository.Add(new Transaction(firstAmount, firstDate));
            _transactionRepository.Add(new Transaction(secondAmount, secondDate));

            var transactions = _transactionRepository.GetAll();

            Assert.AreEqual(firstAmount, transactions.First().Amount);
            Assert.AreEqual(firstDate, transactions.First().Date);
            Assert.AreEqual(secondAmount, transactions.Last().Amount);
            Assert.AreEqual(secondDate, transactions.Last().Date);
        }
    }
}

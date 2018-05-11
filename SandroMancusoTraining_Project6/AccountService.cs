using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandroMancusoTraining_Project6
{
    public class AccountService : IAccountService
    {
        private readonly ITransactionRepository _repository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AccountService(ITransactionRepository repository, IDateTimeProvider dateTimeProvider)
        {
            if (repository == null)
                throw new InvalidRepositoryException("Account");

            _repository = repository;
            _dateTimeProvider = dateTimeProvider;
        }

        public void Deposit(int amount)
        {
            _repository.AddTransaction(new Transaction(amount, _dateTimeProvider.GetCurrentTime()));
        }

        public void Withdraw(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void PrinStatement()
        {
            throw new System.NotImplementedException();
        }
    }
}

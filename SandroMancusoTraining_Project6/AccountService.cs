using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandroMancusoTraining_Project6
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            if (repository == null)
                throw new InvalidRepositoryException("Account");

            _repository = repository;
        }

        public void Deposit(int amount)
        {
            throw new System.NotImplementedException();
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

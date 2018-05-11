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

            if (dateTimeProvider == null)
                throw new InvalidProviderException("DateTime");

            _repository = repository;
            _dateTimeProvider = dateTimeProvider;
        }

        public void Deposit(int amount)
        {
            _repository.Add(new Transaction(amount, _dateTimeProvider.GetCurrentTime()));
        }

        public void Withdraw(int amount)
        {
            _repository.Add(new Transaction(-amount, _dateTimeProvider.GetCurrentTime()));
        }

        public void PrinStatement()
        {
            throw new System.NotImplementedException();
        }
    }
}

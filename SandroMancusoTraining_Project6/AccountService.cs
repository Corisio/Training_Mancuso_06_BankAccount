namespace SandroMancusoTraining_Project6
{
    public class AccountService : IAccountService
    {
        private readonly ITransactionRepository _repository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IStatementFormatter _statementFormatter;

        public AccountService(
            ITransactionRepository repository, 
            IDateTimeProvider dateTimeProvider,
            IStatementFormatter statementFormatter)
        {
            if (repository == null)
                throw new InvalidRepositoryException("Account");

            if (dateTimeProvider == null)
                throw new InvalidProviderException("DateTime");

            _repository = repository;
            _dateTimeProvider = dateTimeProvider;
            _statementFormatter = statementFormatter;
        }

        public void Deposit(int amount)
        {
            _repository.Add(new Transaction(amount, _dateTimeProvider.GetCurrentTime()));
        }

        public void Withdraw(int amount)
        {
            _repository.Add(new Transaction(-amount, _dateTimeProvider.GetCurrentTime()));
        }

        public void PrintStatement()
        {
            var transactions = _repository.GetAll();

            _statementFormatter.GenerateStatement(transactions);
        }
    }
}

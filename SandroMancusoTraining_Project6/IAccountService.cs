namespace SandroMancusoTraining_Project6
{
    public interface IAccountService
    {
        void Deposit(int amount);
        void Withdraw(int amount);
        void PrintStatement();
    }
}
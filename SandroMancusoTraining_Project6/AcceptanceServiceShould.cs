using NUnit.Framework;

namespace SandroMancusoTraining_Project6
{
    [TestFixture]
    public class AcceptanceServiceShould
    {
        [Test]
        public void throw_invalid_repository_exception_when_initialized_with_null_account_repository()
        {
            InvalidRepositoryException capturedException = null;
            IAccountRepository repository = null;
            try
            {
                new AccountService(repository);
            }
            catch (InvalidRepositoryException e)
            {
                capturedException = e;
            }

            Assert.IsNotNull(capturedException);
            Assert.AreEqual("Account", capturedException.RepositoryName);
        }
    }
}

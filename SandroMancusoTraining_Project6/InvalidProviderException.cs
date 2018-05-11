using System;

namespace SandroMancusoTraining_Project6
{
    internal class InvalidProviderException : Exception
    {
        public InvalidProviderException(string repositoryName)
        {
            RepositoryName = repositoryName;
        }

        public string RepositoryName { get; set; }
    }
}
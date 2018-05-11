using System;

namespace SandroMancusoTraining_Project6
{
    internal class InvalidRepositoryException : Exception
    {
        public InvalidRepositoryException(string repositoryName)
        {
            RepositoryName = repositoryName;
        }

        public string RepositoryName { get; set; }
    }
}
namespace NBootstrap
{
    using System;
    using NHelpfulException;

    public class BootstrapperException : HelpfulException
    {
        private const string DefaultMessage = "There was a problem bootstrapping the application.";

        public BootstrapperException(string problemDescription = default(string),
                                     Exception innerException = default(Exception))
            : base(DefaultMessage + " " + problemDescription ?? String.Empty, innerException: innerException) {}
    }
}
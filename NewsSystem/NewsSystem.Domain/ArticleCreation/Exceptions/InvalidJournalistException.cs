namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using NewsSystem.Domain.Common;

    internal sealed class InvalidJournalistException : BaseDomainException
    {
        public InvalidJournalistException()
        {
        }

        public InvalidJournalistException(string error) => this.Error = error;
    }
}

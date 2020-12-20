namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using NewsSystem.Domain.Common;

    public class InvalidJournalistException : BaseDomainException
    {
        public InvalidJournalistException()
        {
        }

        public InvalidJournalistException(string error) => this.Error = error;
    }
}

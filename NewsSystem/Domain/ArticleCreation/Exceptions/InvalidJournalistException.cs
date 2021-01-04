namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using Common;

    public class InvalidJournalistException : BaseDomainException
    {
        public InvalidJournalistException()
        {
        }

        public InvalidJournalistException(string error) => this.Error = error;
    }
}

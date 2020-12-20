namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using Common;

    internal sealed class InvalidArticleException : BaseDomainException
    {
        public InvalidArticleException()
        {

        }

        public InvalidArticleException(string error) => this.Error = error;
    }
}

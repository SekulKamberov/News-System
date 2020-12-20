namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using Common;

    public class InvalidArticleException : BaseDomainException
    {
        public InvalidArticleException()
        {

        }

        public InvalidArticleException(string error) => this.Error = error;
    }
}

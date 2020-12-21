namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using NewsSystem.Domain.Common;

    public class InvalidCommentException : BaseDomainException
    {
        public InvalidCommentException()
        {

        }

        public InvalidCommentException(string error) => this.Error = error;
    }
}

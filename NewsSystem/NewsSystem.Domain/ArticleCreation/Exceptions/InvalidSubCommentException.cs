namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using NewsSystem.Domain.Common;

    public class InvalidSubCommentException : BaseDomainException
    {
        public InvalidSubCommentException()
        {

        }

        public InvalidSubCommentException(string error) => this.Error = error;
    }
}

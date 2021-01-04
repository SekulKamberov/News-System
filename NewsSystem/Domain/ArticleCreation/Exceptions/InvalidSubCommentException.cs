namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using Common;

    public class InvalidSubCommentException : BaseDomainException
    {
        public InvalidSubCommentException()
        {
        }

        public InvalidSubCommentException(string error) => this.Error = error;
    }
}

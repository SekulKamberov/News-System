namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using Common;

    public class InvalidOptionsException : BaseDomainException
    {
        public InvalidOptionsException()
        {
        }

        public InvalidOptionsException(string error) => this.Error = error;
    }
}

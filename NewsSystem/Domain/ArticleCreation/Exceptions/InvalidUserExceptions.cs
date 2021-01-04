namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using Common;
    public class InvalidUserExceptions : BaseDomainException
    {
        public InvalidUserExceptions()
        {
        }

        public InvalidUserExceptions(string error) => this.Error = error;
    }
}

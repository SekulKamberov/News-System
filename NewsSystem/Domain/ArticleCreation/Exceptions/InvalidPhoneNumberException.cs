namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using Common;

    public class InvalidPhoneNumberException : BaseDomainException
    {
        public InvalidPhoneNumberException()
        {
        }

        public InvalidPhoneNumberException(string error) => this.Error = error;
    }
}

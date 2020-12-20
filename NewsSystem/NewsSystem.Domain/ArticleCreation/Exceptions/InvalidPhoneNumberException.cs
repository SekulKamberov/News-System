namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using NewsSystem.Domain.Common;

    public class InvalidPhoneNumberException : BaseDomainException
    {
        public InvalidPhoneNumberException()
        {

        }

        public InvalidPhoneNumberException(string error) => this.Error = error;
    }
}

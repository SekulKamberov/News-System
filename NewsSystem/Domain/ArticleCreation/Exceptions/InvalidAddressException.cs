namespace NewsSystem.Domain.ArticleCreation.Exceptions
{
    using NewsSystem.Domain.Common;

    internal sealed class InvalidAddressException : BaseDomainException
        {
            public InvalidAddressException()
            {
            }

            public InvalidAddressException(string error) => this.Error = error;
    }
}

namespace NewsSystem.Domain.ArticleCreation.Models.Journalists
{
    using NewsSystem.Domain.ArticleCreation.Exceptions;
    using NewsSystem.Domain.Common.Models; 

    public class Address : ValueObject
    {
        internal Address(string value)
        {
            Guard.ForStringLength<InvalidAddressException>(
                value,
                ModelConstants.Address.AddressMinLength,
                ModelConstants.Address.AddressMaxLength);

            this.Value = value;
        }

        private Address()
        {
            this.Value = default!;
        }

        public string Value { get; }

        public static implicit operator string(Address address)
            => address.Value;

        public static implicit operator Address(string address)
            => new Address(address);
    }
}

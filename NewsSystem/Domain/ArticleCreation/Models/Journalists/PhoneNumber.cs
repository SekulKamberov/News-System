namespace NewsSystem.Domain.ArticleCreation.Models.Journalists
{
    using System.Text.RegularExpressions;
     
    using Domain.Common.Models;
    using Domain.ArticleCreation.Exceptions;

    public class PhoneNumber : ValueObject
    {
        internal PhoneNumber(string number)
        {
            this.Validate(number);

            if (!Regex.IsMatch(number, ModelConstants.PhoneNumber.PhoneNumberRegularExpression))
            {
                throw new InvalidPhoneNumberException("Phone number must start with a '+' and contain only digits afterwards.");
            }

            this.Number = number;
        }

        internal PhoneNumber()
        {
            this.Number = default!;
        }

        public string Number { get; }

        public static implicit operator string(PhoneNumber number) => number.Number;

        public static implicit operator PhoneNumber(string number) => new PhoneNumber(number);

        private void Validate(string phoneNumber)
            => Guard.ForStringLength<InvalidPhoneNumberException>(
                phoneNumber,
                ModelConstants.PhoneNumber.MinPhoneNumberLength,
                ModelConstants.PhoneNumber.MaxPhoneNumberLength,
                nameof(PhoneNumber));
    }
}

namespace NewsSystem.Domain.ArticleCreation.Models.Journalists
{ 
    using System.Text.RegularExpressions;

    using NewsSystem.Domain.ArticleCreation.Exceptions;
    using NewsSystem.Domain.Common.Models;

    public class PhoneNumber : ValueObject
    {
        internal PhoneNumber(string number)
        {
            this.Validate(number);

            if (!Regex.IsMatch(number, ModelConstants.PhoneNumber.MaxPhoneNumberRegularExpression))
            {
                throw new InvalidPhoneNumberException("Phone number must start with a '+' and contain only digits afterwards.");
            }

            this.Number = number;
        }

        public string Number { get; }

        public static implicit operator string(PhoneNumber number)
            => number.Number;

        public static implicit operator PhoneNumber(string number)
            => new PhoneNumber(number);

        private void Validate(string PhoneNumber)
            => Guard.ForStringLength<InvalidPhoneNumberException>(
                PhoneNumber,
                ModelConstants.PhoneNumber.MaxPhoneNumberLength,
                ModelConstants.PhoneNumber.MaxPhoneNumberLength,
                nameof(PhoneNumber));
    }
}

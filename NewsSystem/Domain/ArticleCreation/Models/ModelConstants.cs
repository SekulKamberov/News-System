namespace NewsSystem.Domain.ArticleCreation.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

        public class Category
        {
            public const int MinNameLength = 5;
            public const int MaxNameLength = 15;

            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 1000;
        }

        public class Comment
        {
            public const int MinTitleLength = 3;
            public const int MaxTitleLength = 100;

            public const int MinContentLength = 10;
            public const int MaxContentLength = 300;
        }

        public class SubComment
        {
            public const int MinTitleLength = 3;
            public const int MaxTitleLength = 30;

            public const int MinContentLength = 10;
            public const int MaxContentLength = 100;
        }

        public class Article
        {
            public const int MinTitleLength = 3;
            public const int MaxTitleLength = 100;

            public const int MinContentLength = 10;
            public const int MaxContentLength = 1000;
        }

        public class Journalist
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;

            public const int MinPhoneNumberLength = 10;
            public const int MaxPhoneNumberLength = 17;
        }

        public class Address
        {
            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 30;
        }

        public class PhoneNumber
        {
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"\+[0-9]*";
        }

        public class DateRange
        {
            public const int MinNumberOfSeats = 2;
            public const int MaxNumberOfSeats = 50;
        }

    }
}

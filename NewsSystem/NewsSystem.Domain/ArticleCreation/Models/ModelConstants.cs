namespace NewsSystem.Domain.ArticleCreation.Models
{
    public class ModelConstants
    {
        public class Article
        {
            public const int MinTitleLength = 3;
            public const int MaxTitleLength = 100;

            public const int MinContentLength = 10;
            public const int MaxContentLength = 1000;
        }

        public class Common 
        {
            public const int MaxUrlLength = 2048;
        }

        public class Journalist
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;
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
            public const string MaxPhoneNumberRegularExpression = @"\+[0-9]*";
        }

        public class Category
        {
            public const int MinNameLength = 5;
            public const int MaxNameLength = 15;

            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 1000;
        }
    }
}

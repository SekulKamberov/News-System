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
    }
}

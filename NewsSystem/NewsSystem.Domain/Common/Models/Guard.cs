﻿namespace NewsSystem.Domain.Common.Models
{
    using NewsSystem.Domain.ArticleCreation.Models;

    public static class Guard
    {
        public static void AgainstEmptyString<TExeption>(string value, string name = "Value")
            where TExeption : BaseDomainException, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            ThrowException<TExeption>($"{name} can not be null or empty.");
        }

        public static void ForStringLength<TExeption>(string value, int minLength, int maxLength, string name = "Value")
            where TExeption : BaseDomainException, new()
        {
            AgainstEmptyString<TExeption>(value, name);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TExeption>($"{name} must have between {minLength} and {maxLength} symbols.");
        }

        public static void AgainstOutOfRange<TExeption>(string value)
            where TExeption : BaseDomainException, new()
        {
 
        }

        public static void AgainstOutOfRange<TExeption>(string value, int gg) //yo do 
            where TExeption : BaseDomainException, new()
        {

        }
        public static void ForValidUrl<TExeption>(string url, string name = "Name")
            where TExeption : BaseDomainException, new()
        {
            if (url.Length <= ModelConstants.Common.MaxUrlLength) //to do: Is well formed UriString
            {
                return;
            }

            ThrowException<TExeption>($"{name} must be a valid URL.");
        }

        public static void Against<TExeption>(string value)
             where TExeption : BaseDomainException, new()
        {

        }

        private static void ThrowException<TExeption>(string message)
            where TExeption : BaseDomainException, new() 
        {
            var exception = new TExeption
            {
                Error = message
            };

            throw exception;
        }
 
    }
}
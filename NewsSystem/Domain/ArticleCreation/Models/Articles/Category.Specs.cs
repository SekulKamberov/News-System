namespace NewsSystem.Domain.Dealerships.Models.Articles
{
    using System;
    
    using FluentAssertions;
    using Xunit;

    using Domain.ArticleCreation.Exceptions;
    using Domain.ArticleCreation.Models.Articles;

    public class CategorySpecs
    {
        [Fact]
        public void ValidCategoryShouldNotThrowException()
        {
            // Act
            Action act = () => new Category("Valid name", "Valid description text");

            // Assert
            act.Should().NotThrow<InvalidArticleException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            // Act
            Action act = () => new Category("", "Valid description text");

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }
    }
}

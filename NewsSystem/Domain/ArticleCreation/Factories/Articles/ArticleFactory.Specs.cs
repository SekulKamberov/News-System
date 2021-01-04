namespace NewsSystem.Domain.ArticleCreation.Factories.Articles
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;
    using Xunit;

    public class ArticleFactorySpecs
    {
        //[Fact]
        //public void BuildShouldThrowExceptionIfCommentIsNotSet()
        //{
        //    // Assert
        //    var articleFactory = new ArticleFactory();

        //    // Act
        //    Action act = () => articleFactory
        //        .WithCategory("TestCategory", "TestDescription") 
        //        .Build();

        //    // Assert
        //    act.Should().Throw<InvalidArticleException>();
        //}

        [Fact]
        public void BuildShouldThrowExceptionIfTitleAreNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithTitle("Test Title")
                .WithCategory("TestCategory", "TestDescription")
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfCategoryIsNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithTitle("Some Title")
                .WithContent("Some Content")
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldCreateArticleIfEveryPropertyIsSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            var article = articleFactory
                .WithTitle("Title for Test")
                .WithContent("Some text desctiption")
                .WithCategory(CategoryFakes.ValidCategoryName, "TestCategoryDescription")
                .WithImageUrl("http://test.image.url")
                .Build();

            // Assert
            article.Should().NotBeNull();
        }
    }
}

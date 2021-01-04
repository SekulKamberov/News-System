namespace NewsSystem.Domain.Dealerships.Models.Journalists
{
    using Articles;
    using FakeItEasy;
    using FluentAssertions;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;
    using NewsSystem.Domain.ArticleCreation.Models.Journalists;
    using Xunit;

    public class JournalistSpecs
    {
        [Fact]
        public void AddArticleShouldSaveArticle()
        {
            // Arrange
            var journalist = new Journalist("123", "Valid journalist", "Sofia", "359897456654");
            var article = A.Dummy<Article>();

            // Act
            journalist.AddArticle(article);

            // Assert
            journalist.Articles.Should().Contain(article);
        }
    }
}

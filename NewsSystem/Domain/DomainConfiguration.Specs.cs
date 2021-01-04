namespace NewsSystem.Domain
{
    using Microsoft.Extensions.DependencyInjection;

    using Xunit;
    using FluentAssertions;

    using ArticleCreation.Factories.Articles;
    using ArticleCreation.Factories.Journalists;

    public class DomainConfigurationSpecs
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IJournalistFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<IArticleFactory>()
                .Should()
                .NotBeNull();
        }
    }
}

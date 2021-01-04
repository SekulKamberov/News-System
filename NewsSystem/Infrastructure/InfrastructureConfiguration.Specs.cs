namespace NewsSystem.Infrastructure
{
    using System;
    using System.Reflection; 
    using AutoMapper; 
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Application.ArticleCreation.Articles;
    using Infrastructure.ArticleCreation;
    using Infrastructure.Common.Persistence;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<NewsDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddTransient(_ => A.Fake<IArticleCreationDbContext>());

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IArticleRepository>()
                .Should()
                .NotBeNull();
        }
    }
}

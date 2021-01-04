namespace NewsSystem.Infrastructure.ArticleCreation
{
    using Microsoft.EntityFrameworkCore;

    using Identity;

    using Common.Persistence;

    using Domain.ArticleCreation.Models.Articles;
    using Domain.ArticleCreation.Models.Journalists;

    public interface IArticleCreationDbContext : IDbContext
    {
        DbSet<Article> Articles { get; }

        DbSet<Category> Categories { get; }

        DbSet<Comment> Comments { get; }

        DbSet<Journalist> Journalists { get; }

        DbSet<User> Users { get; }
    }
}

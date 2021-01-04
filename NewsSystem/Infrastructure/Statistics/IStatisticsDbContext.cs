namespace NewsSystem.Infrastructure.Statistics
{
    using Common.Persistence;
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;

    public interface IStatisticsDbContext : IDbContext
    {
        DbSet<Statistics> Statistics { get; }

        DbSet<ArticleView> ArticleViews { get; }
    }
}

namespace NewsSystem.Application.Statistics
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Statistics.Models;
    using Queries.Current;

    public interface IStatisticsRepository : IRepository<Statistics>
    {
        Task<GetCurrentStatisticsOutputModel> GetCurrent(CancellationToken cancellationToken = default);

        Task<int> GetArticleViews(int articleId, CancellationToken cancellationToken = default);

        Task IncrementArticles(CancellationToken cancellationToken = default);
    }
}
